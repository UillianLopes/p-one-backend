using Microsoft.EntityFrameworkCore;
using POne.Core.Contracts;
using POne.Core.Enums;
using POne.Core.Extensions;
using POne.Core.Models;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Entities;
using POne.Financial.Domain.Queries.Inputs.Entries;
using POne.Financial.Domain.Queries.Outputs.Entries;
using POne.Financial.Infra.Connections;
using POne.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Infra.Repositories
{
    public class EntryRepository : Repository<POneFinancialDbContext, Entry>, IEntryRepository
    {
        private readonly IAuthenticatedUser _authenticatedUser;

        public EntryRepository(IAuthenticatedUser authenticatedUser, POneFinancialDbContext dbContext) : base(dbContext) => _authenticatedUser = authenticatedUser;

        private IQueryable<Entry> ApplyGeneralFilter(IQueryable<Entry> entries, GetFiltredEntries filter)
        {
            if (filter.Text is string text)
                entries = entries.Where(entry => EF.Functions.Like(entry.Title.ToLower(), $"{text.ToLower()}%"));

            if (filter.Type is EntryOperation type)
                entries = entries.Where(entry => entry.Operation == type);

            if (filter.SubCategories is Guid[] subCategories && subCategories.Any())
                entries = entries.Where(entry => entry.SubCategory != null && subCategories.Contains(entry.SubCategory.Id));

            if (filter.Categories is Guid[] categories && categories.Any())
                entries = entries.Where(entry => entry.Category != null && categories.Contains(entry.Category.Id));

            if (filter.MinValue is decimal minValue)
                entries = entries.Where(entry => entry.Value >= minValue);

            if (filter.MaxValue is decimal maxValue)
                entries = entries.Where(entry => entry.Value <= maxValue);

            return entries;
        }

        private IQueryable<Entry> ApplyNormalEntriesFilter(IQueryable<Entry> entries, GetFiltredEntries filter)
        {
            entries = entries.Where((entry) =>
                entry.Recurrence == null &&
                entry.DueDate.Year == filter.Year &&
                entry.DueDate.Month == filter.Month &&
                entry.Parent == null
            );

            if (filter.IsPaid is bool isPaid)
                if (isPaid)
                    entries = entries.Where(entry => entry.Payments.Sum(p => p.Value) >= entry.Value);
                else
                    entries = entries.Where(entry => entry.Payments.Sum(p => p.Value) < entry.Value);

            entries = filter.PaymentStatus switch
            {
                EntryPaymentStatus.Paid => entries.Where(entry => entry.Payments.Sum(p => p.Value) >= entry.Value),
                EntryPaymentStatus.Opened => entries.Where(entry => entry.Payments.Sum(p => p.Value) < entry.Value),
                EntryPaymentStatus.ToPayToday => entries.Where(entry => entry.DueDate.Date == DateTime.Now.Date),
                EntryPaymentStatus.Overdue => entries.Where(entry => entry.Payments.Sum(p => p.Value) < entry.Value && entry.DueDate.Date < DateTime.Now.Date),
                _ => entries
            };

            return entries;
        }

        private IQueryable<Entry> ApplyRecurrentEntriesFilter(IQueryable<Entry> entries, GetFiltredEntries filter)
        {
            entries = entries
                .Where(e =>
                    e.Recurrence != null &&
                    (
                        e.DueDate.Year < filter.Year ||
                        (e.DueDate.Year == filter.Year && e.DueDate.Month <= filter.Month)
                    ) &&
                    (
                        e.RecurrenceEnd == null ||
                        (
                            e.RecurrenceEnd.Year > filter.Year ||
                            (e.RecurrenceEnd.Year == filter.Year && e.RecurrenceEnd.Month >= filter.Month)
                        )
                    )
                );

            return entries;
        }

        private IEnumerable<Entry> ApplyRecurrentEntriesFilter(IEnumerable<Entry> entries, GetFiltredEntries filter)
        {
            if (filter.IsPaid is bool isPaid)
                if (isPaid)
                    entries = entries.Where(entry => entry.Payments.Sum(p => p.Value) >= entry.Value);
                else
                    entries = entries.Where(entry => entry.Payments.Sum(p => p.Value) < entry.Value);

            entries = filter.PaymentStatus switch
            {
                EntryPaymentStatus.Paid => entries.Where(entry => entry.Payments.Sum(p => p.Value) >= entry.Value),
                EntryPaymentStatus.Opened => entries.Where(entry => entry.Payments.Sum(p => p.Value) < entry.Value),
                EntryPaymentStatus.ToPayToday => entries.Where(entry => entry.DueDate.Date == DateTime.Now.Date),
                EntryPaymentStatus.Overdue => entries.Where(entry => entry.Payments.Sum(p => p.Value) < entry.Value && entry.DueDate.Date < DateTime.Now.Date),
                _ => entries
            };

            return entries;
        }


        public async Task<List<EntryOutput>> GetAllAsync(GetFiltredEntries filter, CancellationToken cancellationToken)
        {
            var entries = _dbContext
                .Entries
                .Where(entry =>
                 (
                    (!_authenticatedUser.IsStandalone && entry.AccountId != null && entry.AccountId == _authenticatedUser.AccountId) ||
                    (_authenticatedUser.IsStandalone && entry.UserId != null && entry.UserId == _authenticatedUser.Id)
                 )
                );

            var normalEntriesQueryable = ApplyGeneralFilter(entries, filter);
            normalEntriesQueryable = ApplyNormalEntriesFilter(entries, filter);

            var recurrentEntiresQueryable = ApplyGeneralFilter(entries, filter);
            recurrentEntiresQueryable = ApplyRecurrentEntriesFilter(entries, filter);

            var recurrentEntries = new List<Entry>();

            foreach (var entry in recurrentEntiresQueryable)
            {
                var dueDates = new List<DateTime>();
                var referenceDate = new DateTime(filter.Year, filter.Month, 1);

                switch (entry.Recurrence)
                {
                    case EntryRecurrence.EverySpecificDayOfMonth:
                        if (entry.RecurrenceDayOfMonth is not int recurrenceDayOfMonth)
                            break;

                        dueDates.Add(referenceDate.GoToThatDay(recurrenceDayOfMonth));
                        break;

                    case EntryRecurrence.EveryLastDayOfMonth:
                        dueDates.Add(referenceDate.GoToLastDayOfMonth());
                        break;

                    case EntryRecurrence.EveryWeek:
                        if (entry.RecurrenceDayOfWeek is not DayOfWeek dayOfWeek)
                            break;

                        dueDates.AddRange(referenceDate.GetDaysOfMonthBasedOnThisDayOfWeek(dayOfWeek));
                        break;
                }

                var generatedEntries = dueDates
                    .Select((dueDate) => entry.Children.FirstOrDefault(c => c.DueDate.Date == dueDate.Date) ?? entry.GenerateChildEntry(dueDate));

                generatedEntries = ApplyRecurrentEntriesFilter(generatedEntries, filter);

                recurrentEntries.AddRange(generatedEntries);
            }

            var entriesOutputs = await normalEntriesQueryable
                .Select(e => new EntryOutput
                {
                    Id = e.Id,
                    Type = e.Operation,
                    Recurrences = e.Installments,
                    Value = e.Value,
                    Index = e.Index,
                    Title = e.Title,
                    DueDate = e.DueDate,
                    Description = e.Description,
                    BarCode = e.BarCode,
                    PaidValue = e.Payments.Sum((payment) => payment.Value),
                    Category = e.Category != null ? new OptionModel
                    {
                        Id = e.Category.Id,
                        Title = e.Category.Name,
                        Color = e.Category.Color
                    } : null,
                    SubCategory = e.SubCategory != null ? new OptionModel
                    {
                        Id = e.SubCategory.Id,
                        Title = e.SubCategory.Name,
                        Color = e.SubCategory.Color
                    } : null,
                    Currency = e.Currency,
                    Payments = e.Payments.Select((payment) => new PaymentOutput
                    {
                        Value = payment.Value,
                        Fees = payment.Fees,
                        Fine = payment.Fine,
                        Wallet = new OptionModel
                        {
                            Title = payment.Wallet.Name,
                            Color = payment.Wallet.Color,
                            Id = payment.Wallet.Id
                        }
                    }).ToArray()
                })
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var recurrentEntriesOutputs = recurrentEntries
                .Select(e => new EntryOutput
                {
                    Id = e.Id,
                    Type = e.Operation,
                    Recurrences = e.Installments,
                    Value = e.Value,
                    Index = e.Index,
                    Title = e.Title,
                    DueDate = e.DueDate,
                    Description = e.Description,
                    BarCode = e.BarCode,
                    PaidValue = e.Payments.Sum((payment) => payment.Value),
                    Category = e.Category != null ? new OptionModel
                    {
                        Id = e.Category.Id,
                        Title = e.Category.Name,
                        Color = e.Category.Color
                    } : null,
                    SubCategory = e.SubCategory != null ? new OptionModel
                    {
                        Id = e.SubCategory.Id,
                        Title = e.SubCategory.Name,
                        Color = e.SubCategory.Color
                    } : null,
                    Currency = e.Currency,
                    Payments = e.Payments.Select((payment) => new PaymentOutput
                    {
                        Value = payment.Value,
                        Fees = payment.Fees,
                        Fine = payment.Fine,
                        Wallet = new OptionModel
                        {
                            Title = payment.Wallet.Name,
                            Color = payment.Wallet.Color,
                            Id = payment.Wallet.Id
                        }
                    }).ToArray()
                })
                .ToList();

            entriesOutputs.AddRange(recurrentEntriesOutputs);

            return entriesOutputs
                .OrderBy(e => e.PaymentStatus)
                .ThenBy(e => e.DueDate)
                .ToList();
        }
    }
}

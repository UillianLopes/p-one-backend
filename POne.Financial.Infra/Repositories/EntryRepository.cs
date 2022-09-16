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

            if (filter.Operation is EntryOperation operation)
                entries = entries.Where(entry => entry.Operation == operation);

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
                !entry.IsDeleted
                && entry.Recurrence == null
                && entry.DueDate != null
                && entry.DueDate.Value.Year == filter.Year
                && entry.DueDate.Value.Month == filter.Month
                && entry.Parent == null
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
                EntryPaymentStatus.ToPayToday => entries.Where(entry => entry.DueDate.Value.Date == DateTime.Now.Date),
                EntryPaymentStatus.Overdue => entries.Where(entry => entry.Payments.Sum(p => p.Value) < entry.Value && entry.DueDate.Value.Date < DateTime.Now.Date),
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
                        e.RecurrenceBegin.Value.Year < filter.Year ||
                        (e.RecurrenceBegin.Value.Year == filter.Year && e.RecurrenceBegin.Value.Month <= filter.Month)
                    ) &&
                    (
                        e.RecurrenceEnd == null ||
                        (
                            e.RecurrenceEnd.Value.Year > filter.Year ||
                            (e.RecurrenceEnd.Value.Year == filter.Year && e.RecurrenceEnd.Value.Month >= filter.Month)
                        )
                    )
                );

            return entries;
        }

        private IEnumerable<Entry> ApplyRecurrentEntriesFilter(IEnumerable<Entry> entries, GetFiltredEntries filter)
        {
            entries = entries.Where(e => !e.IsDeleted);
            if (filter.IsPaid is bool isPaid)
                if (isPaid)
                    entries = entries.Where(entry => entry.Payments.Sum(p => p.Value) >= entry.Value);
                else
                    entries = entries.Where(entry => entry.Payments.Sum(p => p.Value) < entry.Value);

            entries = filter.PaymentStatus switch
            {
                EntryPaymentStatus.Paid => entries.Where(entry => entry.Payments.Sum(p => p.Value) >= entry.Value),
                EntryPaymentStatus.Opened => entries.Where(entry => entry.Payments.Sum(p => p.Value) < entry.Value),
                EntryPaymentStatus.ToPayToday => entries.Where(entry => entry.DueDate.Value.Date == DateTime.Now.Date),
                EntryPaymentStatus.Overdue => entries.Where(entry => entry.Payments.Sum(p => p.Value) < entry.Value && entry.DueDate.Value.Date < DateTime.Now.Date),
                _ => entries
            };

            return entries;
        }


        public async Task<List<EntryOutput>> GetAllAsync(GetFiltredEntries filter, CancellationToken cancellationToken)
        {
            var entriesQueryable = _dbContext
                .Entries
                .Where(entry =>
                 (
                    (!_authenticatedUser.IsStandalone && entry.AccountId != null && entry.AccountId == _authenticatedUser.AccountId) ||
                    (_authenticatedUser.IsStandalone && entry.UserId != null && entry.UserId == _authenticatedUser.Id)
                 )
                );

            var normalEntriesQueryable = ApplyGeneralFilter(entriesQueryable, filter);
            normalEntriesQueryable = ApplyNormalEntriesFilter(normalEntriesQueryable, filter);

            var recurrentEntiresQueryable = ApplyGeneralFilter(entriesQueryable, filter);
            recurrentEntiresQueryable = ApplyRecurrentEntriesFilter(recurrentEntiresQueryable, filter);

            var recurrentEntries = await recurrentEntiresQueryable
                .ToListAsync(cancellationToken);

            var entries = await normalEntriesQueryable
                .ToListAsync(cancellationToken);

            foreach (var entry in recurrentEntries)
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
                    .Select((dueDate) => entry
                        .Children
                        .FirstOrDefault(child => child.DueDate != null && child.DueDate.Value.Date == dueDate.Date) ?? entry.CreateAChildEntryWithEmptyId(dueDate));

                generatedEntries = ApplyRecurrentEntriesFilter(generatedEntries, filter);
                entries.AddRange(generatedEntries);
            }

            return entries
                .Select(entry => new EntryOutput
                {
                    Id = entry.Id != Guid.Empty ? entry.Id : null,
                    ParentId = entry.Parent?.Id,
                    InstallmentId = entry.InstallmentId,
                    Type = entry.Operation,
                    Recurrences = entry.Installments,
                    Value = entry.Value,
                    Index = entry.Index,
                    Title = entry.Title,
                    DueDate = entry.DueDate,
                    Description = entry.Description,
                    BarCode = entry.BarCode,
                    PaidValue = entry.Payments.Sum((payment) => payment.Value),
                    RecurrenceBegin = entry.Parent != null ? entry.Parent.RecurrenceBegin : null,
                    RecurrenceEnd = entry.Parent != null ? entry.Parent.RecurrenceEnd : null,
                    Recurrence = entry.Recurrence,
                    Wallet = entry.Wallet != null ? new OptionModel
                    {
                        Id = entry.Wallet.Id,
                        Color = entry.Wallet.Color,
                        Title = entry.Wallet.Name
                    } : null,
                    Category = entry.Category != null ? new OptionModel
                    {
                        Id = entry.Category.Id,
                        Title = entry.Category.Name,
                        Color = entry.Category.Color
                    } : null,
                    SubCategory = entry.SubCategory != null ? new OptionModel
                    {
                        Id = entry.SubCategory.Id,
                        Title = entry.SubCategory.Name,
                        Color = entry.SubCategory.Color
                    } : null,
                    Currency = entry.Currency,
                    Payments = entry.Payments.Select((payment) => new PaymentOutput
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
                .OrderBy(e => e.PaymentStatus)
                .ThenBy(e => e.DueDate)
                .ToList();
        }
    }
}

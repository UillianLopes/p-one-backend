using Microsoft.EntityFrameworkCore;
using POne.Core.Contracts;
using POne.Core.Enums;
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

        public Task<List<EntryOutput>> GetAllAsync(GetFiltredEntries filter, CancellationToken cancellationToken)
        {
            var entries = _dbContext
                .Entries
                .Where(entry => (
                    (!_authenticatedUser.IsStandalone && entry.AccountId != null && entry.AccountId == _authenticatedUser.AccountId) ||
                    (_authenticatedUser.IsStandalone && entry.UserId != null && entry.UserId == _authenticatedUser.Id)
                 ) && entry.DueDate.Year == filter.Year && entry.DueDate.Month == filter.Month
                );

            if (filter.Text is string text)
                entries = entries.Where(entry => EF.Functions.Like(entry.Title.ToLower(), $"{text.ToLower()}%"));

            entries = filter.PaymentStatus switch
            {
                EntryPaymentStatus.Paid => entries.Where(entry => entry.Payments.Sum(p => p.Value) >= entry.Value),
                EntryPaymentStatus.Opened => entries.Where(entry => entry.Payments.Sum(p => p.Value) < entry.Value),
                EntryPaymentStatus.ToPayToday => entries.Where(entry => entry.DueDate.Date == DateTime.Now.Date),
                EntryPaymentStatus.Overdue => entries.Where(entry => entry.Payments.Sum(p => p.Value) < entry.Value && entry.DueDate.Date < DateTime.Now.Date),
                _ => entries
            };


            if (filter.Type is EntryType type)
                entries = entries.Where(entry => entry.Type == type);

            if (filter.SubCategories is Guid[] subCategories && subCategories.Any())
                entries = entries.Where(entry => entry.SubCategory != null && subCategories.Contains(entry.SubCategory.Id));

            if (filter.Categories is Guid[] categories && categories.Any())
                entries = entries.Where(entry => entry.Category != null && categories.Contains(entry.Category.Id));

            if (filter.MinValue is decimal minValue)
                entries = entries.Where(entry => entry.Value >= minValue);

            if (filter.MaxValue is decimal maxValue)
                entries = entries.Where(entry => entry.Value <= maxValue);

            if (filter.IsPaid is bool isPaid)
                if (isPaid)
                    entries = entries.Where(entry => entry.Payments.Sum(p => p.Value) >= entry.Value);
                else
                    entries = entries.Where(entry => entry.Payments.Sum(p => p.Value) < entry.Value);

            return entries
                .OrderByDescending(x => x.Creation)
                .Select(e => new EntryOutput
                {
                    Id = e.Id,
                    Type = e.Type,
                    Recurrences = e.Recurrences,
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
        }
    }
}

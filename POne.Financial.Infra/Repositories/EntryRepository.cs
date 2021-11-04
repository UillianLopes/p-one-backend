using Microsoft.EntityFrameworkCore;
using POne.Core.Contracts;
using POne.Core.Enums;
using POne.Core.Extensions.Items;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Domain;
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
                .Where(entry => entry.UserId == _authenticatedUser.Id &&
                (
                    (entry.DueDate != null && entry.DueDate.Value.Year == filter.Year && entry.DueDate.Value.Month == filter.Month) ||
                    (entry.DueDate == null && entry.Creation.Year == filter.Year && entry.Creation.Month == filter.Month)
                ));

            if (filter.Text is string text)
                entries = entries.Where(entry => EF.Functions.Like(entry.Title.ToLower(), $"{text.ToLower()}%"));

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
                .Select(e => new EntryOutput
                {
                    Type = e.Type,
                    Value = e.Value,
                    IsPaid = e.Payments.Sum(p => p.Value) > e.Value,
                    Index = e.Index,
                    Title = e.Title,
                    Description = e.Description,
                    Category = e.Category != null ? new AutoCompleteItem
                    {
                        Id = e.Category.Id,
                        Title = e.Category.Name
                    } : null,
                    SubCategory = e.Category != null ? new AutoCompleteItem
                    {
                        Id = e.SubCategory.Id,
                        Title = e.SubCategory.Name
                    } : null
                }).ToListAsync(cancellationToken);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using POne.Core.Contracts;
using POne.Core.Models;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Entities;
using POne.Financial.Domain.Queries.Inputs.Wallets;
using POne.Financial.Domain.Queries.Outputs.Banks;
using POne.Financial.Domain.Queries.Outputs.Wallets;
using POne.Financial.Infra.Connections;
using POne.Infra.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Infra.Repositories
{
    public class WalletRepository : Repository<POneFinancialDbContext, Wallet>, IWalletRepository
    {
        private readonly IAuthenticatedUser _authenticatedUser;

        public WalletRepository(IAuthenticatedUser authenticatedUser, POneFinancialDbContext dbContext) : base(dbContext) => _authenticatedUser = authenticatedUser;

        public Task<List<OptionModel<WalletOptionsExtra>>> GetAllAsOptionsAsync(GetAllWalletsAsOptions filter, CancellationToken cancellationToken)
        {
            var query = _dbContext
               .Wallets
               .Where(wallet => (
                   (!_authenticatedUser.IsStandalone && wallet.AccountId != null && wallet.AccountId == _authenticatedUser.AccountId) ||
                   (_authenticatedUser.IsStandalone && wallet.UserId != null && wallet.UserId == _authenticatedUser.Id)
               ));

            if (filter.Currency is string curreny)
                query = query
                    .Where(c => c.Currency == curreny);

            return query
                .OrderBy(c => c.Name)
                .Select(e => new OptionModel<WalletOptionsExtra>
                {
                    Id = e.Id,
                    Title = e.Name,
                    SubTitle = e.Bank != null ? e.Bank.Name : string.Empty,
                    Color = e.Color,
                    Extra = new WalletOptionsExtra
                    {
                        Currency = e.Currency,
                        Value = e.Value
                    }
                })
                .ToListAsync(cancellationToken);
        }

        public Task<List<WalletOutput>> GetAllAsync(GetAllWallets filter, CancellationToken cancellationToken)
        {
            var query = _dbContext
                .Wallets
                .Where(wallet => (
                    (!_authenticatedUser.IsStandalone && wallet.AccountId != null && wallet.AccountId == _authenticatedUser.AccountId) ||
                    (_authenticatedUser.IsStandalone && wallet.UserId != null && wallet.UserId == _authenticatedUser.Id)
                ));

            if (filter.Currency is string curreny)
                query = query
                    .Where(c => c.Currency == curreny);

            return query
                .OrderBy(c => c.Name)
                .Select(c => new WalletOutput
                {
                    Id = c.Id,
                    Name = c.Name,
                    Value = c.Value,
                    Agency = c.Agency,
                    Color = c.Color,
                    Currency = c.Currency,
                    Bank = c.Bank != null ? new BankOutput
                    {
                        Id = c.Bank.Id,
                        Name = c.Bank.Name,
                        Code = c.Bank.Code
                    } : null,
                    Number = c.Number,
                    Type = c.Type,
                })
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}

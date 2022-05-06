﻿using Microsoft.EntityFrameworkCore;
using POne.Core.Contracts;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Entities;
using POne.Financial.Domain.Queries.Outputs.Wallets;
using POne.Financial.Domain.Queries.Outputs.Banks;
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

        public Task<List<WalletOutput>> GetAllAsync(CancellationToken cancellationToken) => _dbContext
            .Wallets
            .Where(c => c.UserId == _authenticatedUser.Id)
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

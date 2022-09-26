using POne.Core.Contracts;
using POne.Core.Models;
using POne.Financial.Domain.Entities;
using POne.Financial.Domain.Queries.Inputs.Wallets;
using POne.Financial.Domain.Queries.Outputs.Wallets;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Domain.Contracts
{
    public interface IWalletRepository : IRepository<Wallet>, IAsOptionsRepository<GetAllWalletsAsOptions, OptionModel<WalletOptionsExtra>>
    {
        Task<List<WalletOutput>> GetAllAsync(GetAllWallets query, CancellationToken cancellationToken);
    }
}

using POne.Core.CQRS;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Queries.Inputs.Wallets;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Business.QueryHandlers
{
    public class WalletQueryHandler : IQueryHandler<GetAllWallets>, IQueryHandler<GetAllWalletsAsOptions>
    {
        private readonly IWalletRepository _balanceRepository;

        public WalletQueryHandler(IWalletRepository categoryRepository)
        {
            _balanceRepository = categoryRepository;
        }

        public async Task<IQueryOutput> Handle(GetAllWallets query, CancellationToken cancellationToken)
        {
            var balances = await _balanceRepository
                .GetAllAsync(query, cancellationToken);

            return QueryOutput.Ok(balances);
        }

        public async Task<IQueryOutput> Handle(GetAllWalletsAsOptions request, CancellationToken cancellationToken)
        {
            var balances = await _balanceRepository
                  .GetAllAsOptionsAsync(request, cancellationToken);

            return QueryOutput.Ok(balances);
        }
    }
}

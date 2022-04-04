using POne.Core.CQRS;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Queries.Inputs.Wallets;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Business.QueryHandlers
{
    public class WalletQueryHandler : IQueryHandler<GetAllWallets>
    {
        private readonly IWalletRepository _balanceRepository;

        public WalletQueryHandler(IWalletRepository categoryRepository)
        {
            _balanceRepository = categoryRepository;
        }

        public async Task<IQueryOutput> Handle(GetAllWallets _, CancellationToken cancellationToken)
        {
            var balances = await _balanceRepository.GetAllAsync(cancellationToken);

            return QueryOutput.Ok(balances);
        }
    }
}

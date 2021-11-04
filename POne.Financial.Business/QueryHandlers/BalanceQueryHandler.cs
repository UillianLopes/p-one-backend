using POne.Core.CQRS;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Queries.Inputs.Balances;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Business.QueryHandlers
{
    public class BalanceQueryHandler : IQueryHandler<GetAllBalances>
    {
        private readonly IBalanceRepository _balanceRepository;

        public BalanceQueryHandler(IBalanceRepository categoryRepository)
        {
            _balanceRepository = categoryRepository;
        }

        public async Task<IQueryOutput> Handle(GetAllBalances _, CancellationToken cancellationToken)
        {
            var balances = await _balanceRepository.GetAllAsync(cancellationToken);

            return QueryOutput.Ok(balances);
        }
    }
}

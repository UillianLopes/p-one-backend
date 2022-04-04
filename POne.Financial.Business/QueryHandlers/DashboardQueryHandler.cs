using POne.Core.CQRS;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Queries.Inputs.Dashboards;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Business.QueryHandlers
{
    public class DashboardQueryHandler : IQueryHandler<GetBalanceOverTime>
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardQueryHandler(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<IQueryOutput> Handle(GetBalanceOverTime request, CancellationToken cancellationToken)
        {
            if (request.UseMock)
            {
               
            }
            var output = await _dashboardRepository.GetBalanceOverTimeAsync(request, cancellationToken);

            return QueryOutput.Ok(output);
        }
    }
}

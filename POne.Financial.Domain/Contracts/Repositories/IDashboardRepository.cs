using POne.Core.Queries.Outputs;
using POne.Financial.Domain.Queries.Inputs.Dashboards;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Domain.Contracts
{
    public interface IDashboardRepository
    {
        Task<LineChartDataOutput> GetBalanceOverTimeAsync(GetBalanceOverTime request, CancellationToken cancellationToken);
    }
}

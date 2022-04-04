using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POne.Core.Contracts;
using POne.Core.Mvc;
using POne.Financial.Domain.Queries.Inputs.Dashboards;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class DashboardController : BaseController
    {
        public DashboardController(IMediator mediator, IUow uow) : base(mediator, uow)
        {
        }

        [HttpGet("[action]")]
        public Task<IActionResult> BalanceOverTimeAsync([FromQuery] GetBalanceOverTime query, CancellationToken cancellationToken) => QueryAsync(query, cancellationToken);
    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POne.Core.Contracts;
using POne.Core.Mvc;
using POne.Financial.Domain.Queries.Inputs.Notifications;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Api.Controllers
{

    [Route("[controller]")]
    [Authorize]
    public class NotificationController : BaseController
    {
        public NotificationController(IMediator mediator, IUow uow) : base(mediator, uow)
        {
        }

        [HttpGet("[action]")]
        public Task<IActionResult> UnreadAsync(CancellationToken cancellationToken) => QueryAsync(new GetUnreadNotifications(), cancellationToken);
    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POne.Core.Contracts;
using POne.Core.Mvc;
using POne.Notifier.Domain.Commands.Inputs;
using POne.Notifier.Domain.Queries.Inputs.Notifications;

namespace POne.Notifier.Api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class NotificationController : BaseController
    {
        public NotificationController(IMediator mediator, IUow uow) : base(mediator, uow)
        {
        }

        [HttpPost]
        public Task<IActionResult> CreateAsync([FromBody] CreateNotificationCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpGet("[action]")]
        public Task<IActionResult> UnreadAsync(CancellationToken cancellationToken) => QueryAsync(new GetUnreadNotifications(), cancellationToken);

        [HttpPut("{id}/[action]")]
        public Task<IActionResult> MarkAsReadAsync([FromRoute] Guid id, CancellationToken cancellationToken) => SendAsync(new MarkNotificationAsReadCommand { Id = id }, cancellationToken);

        [HttpPut("{id}/[action]")]
        public Task<IActionResult> MarkAsUnreadAsync([FromRoute] Guid id, CancellationToken cancellationToken) => SendAsync(new MarkNotificationAsUnreadCommand { Id = id }, cancellationToken);
    }
}

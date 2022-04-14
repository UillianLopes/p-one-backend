using POne.Core.Contracts;
using POne.Core.CQRS;
using POne.Core.Enums;
using POne.Core.Events;
using POne.Domain.Commands.Inputs;
using POne.Financial.Domain.Contracts.Facades;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Business.EventHandlers
{
    public class NotificationEventHandler : IEventHandler<NotifyEvent>
    {
        private readonly INotifierApiFacade _notifierApiFacade;
        private readonly IAuthenticatedUser _authenticatedUser;

        public NotificationEventHandler(INotifierApiFacade notifierApiFacade, IAuthenticatedUser authenticatedUser)
        {
            _notifierApiFacade = notifierApiFacade;
            _authenticatedUser = authenticatedUser;
        }

        public async Task Handle(NotifyEvent notification, CancellationToken cancellationToken)
        {
            var command = new CreateNotificationCommand
            {
                Application = POneApplication.Financial,
                Type = notification.Type,
                Title = notification.Title,
                Text = notification.Text,
                UserId = _authenticatedUser.Id
            };

            await _notifierApiFacade.NotifyAsync(command, cancellationToken);

        }
    }
}

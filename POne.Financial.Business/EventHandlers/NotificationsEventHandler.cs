using POne.Core.Contracts;
using POne.Core.CQRS;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Contracts.Facades;
using POne.Financial.Domain.Entities;
using POne.Financial.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Business.EventHandlers
{

    public class NotificationsEventHandler : IEventHandler<NotifyEvent>
    {
        private readonly INotificationsHubFacade _notificationsHubFacade;
        private readonly IAuthenticatedUser _authenticatedUser;
        private readonly INotificationRepository _notificationRepository;
        public NotificationsEventHandler(INotificationsHubFacade notificationsHubFacade, IAuthenticatedUser authenticatedUser, INotificationRepository notificationRepository)
        {
            _notificationsHubFacade = notificationsHubFacade;
            _authenticatedUser = authenticatedUser;
            _notificationRepository = notificationRepository;
        }

        public async Task Handle(NotifyEvent command, CancellationToken cancellationToken)
        {

            var notification = new Notification(
                command.Title,
                command.Text,
                command.Type,
                _authenticatedUser.Id
            );


            await _notificationRepository
                .CreateAync(notification, cancellationToken);

            await _notificationsHubFacade
                .NotificateAsync(
                    _authenticatedUser.Id.ToString(),
                        command with
                        {
                            Id = notification.Id
                        },
                        cancellationToken
                   );
        }
    }
}

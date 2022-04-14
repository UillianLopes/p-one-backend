using POne.Core.CQRS;
using POne.Notifier.Domain.Contracts.Facades;
using POne.Notifier.Domain.Events.Notifications;

namespace POne.Notifier.Business.EventHandlers
{
    public class NotificationEventHandler : IEventHandler<NotificationCreatedEvent>
    {
        private readonly INotificationsHubFacade _notificationHubFacade;

        public NotificationEventHandler(INotificationsHubFacade notificationHubFacade)
        {
            _notificationHubFacade = notificationHubFacade;
        }

        public async Task Handle(NotificationCreatedEvent notification, CancellationToken cancellationToken)
        {
            if (notification.Id is Guid id)
            {
                await _notificationHubFacade.NotificateAsync(id.ToString(), notification, cancellationToken);
                return;
            }


            await _notificationHubFacade.NotificateAsync(notification, cancellationToken);
        }
    }
}

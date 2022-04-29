using POne.Notifier.Api.Hubs;
using POne.Notifier.Domain.Contracts.Facades;

namespace POne.Notifier.Api.Facades
{
    public class NotificationsHubFacade : INotificationsHubFacade
    {
        private readonly NotificationsHub _notificationsHub;

        public NotificationsHubFacade(NotificationsHub notificationsHub)
        {
            _notificationsHub = notificationsHub;
        }

        public async Task NotificateAsync(string userId, object notification, CancellationToken cancellationToken)
        {
            await _notificationsHub.SendToUserAsync(userId, "NOTIFICATE", notification, cancellationToken);
        }

        public async Task NotificateAsync(object notification, CancellationToken cancellationToken)
        {
            await _notificationsHub.SendToAllAsync("NOTIFICATE", notification, cancellationToken);
        }
    }
}

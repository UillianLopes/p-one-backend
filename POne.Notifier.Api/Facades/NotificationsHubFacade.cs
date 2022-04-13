using Microsoft.AspNetCore.SignalR;
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
            await _notificationsHub
                .Clients
                .All
                .SendAsync("NOTIFICATE", notification, cancellationToken);
        }
    }
}

using Microsoft.AspNetCore.SignalR;
using POne.Financial.Api.Hubs;
using POne.Financial.Domain.Contracts.Facades;
using POne.Financial.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Api.Facades
{
    public class NotificationsHubFacade : INotificationsHubFacade
    {
        private readonly NotificationsHub _notificationsHub;

        public NotificationsHubFacade(NotificationsHub notificationsHub)
        {
            _notificationsHub = notificationsHub;
        }

        public async Task NotificateAsync(string userId, NotifyEvent notification, CancellationToken cancellationToken)
        {
            await _notificationsHub
                .Clients
                .All
                .SendAsync("NOTIFICATE", notification, cancellationToken);
        }
    }
}

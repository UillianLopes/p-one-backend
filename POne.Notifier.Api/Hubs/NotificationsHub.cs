using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace POne.Notifier.Api.Hubs
{
    [Authorize]
    public class NotificationsHub : Hub
    {
        public Task SendToUserAsync(string userId, string method, object data, CancellationToken cancellationToken) => Clients
            .User(userId.ToString())
            .SendAsync(method, data, cancellationToken);

        public Task SendToAllAsync(string method, object data, CancellationToken cancellationToken) => Clients
            .All
            .SendAsync(method, data, cancellationToken);

        public void SendToGroupAsync(string group, string method, object data, CancellationToken cancellationToken) => Clients
            .Group(group)
            .SendAsync(method, data, cancellationToken);
    }
}

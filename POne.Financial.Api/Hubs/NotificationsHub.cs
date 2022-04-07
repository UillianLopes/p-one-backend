using IdentityModel;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace POne.Financial.Api.Hubs
{
    public class UserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.FindFirst(JwtClaimTypes.Id)?.Value;
        }
    }

    public class NotificationsHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}

using POne.Financial.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Domain.Contracts.Facades
{
    public interface INotificationsHubFacade
    {
        Task NotificateAsync(string userId, NotifyEvent notification, CancellationToken cancellationToken);
    }
}

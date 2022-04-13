using POne.Core.Contracts;
using POne.Notifier.Domain.Entities;
using POne.Notifier.Domain.Queries.Inputs.Notifications;
using POne.Notifier.Domain.Queries.Outputs.Notifications;

namespace POne.Notifier.Domain.Contracts.Repositories
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task<List<NotificationOutput>> GetUnreadNotificationsAsync(GetUnreadNotifications request, CancellationToken cancellationToken);
    }
}

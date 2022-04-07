using POne.Core.Contracts;
using POne.Financial.Domain.Entities;
using POne.Financial.Domain.Queries.Inputs.Notifications;
using POne.Financial.Domain.Queries.Outputs.Notifications;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Domain.Contracts
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task<List<NotificationOutput>> GetUnreadNotificationsAsync(GetUnreadNotifications request, CancellationToken cancellationToken);
    }
}

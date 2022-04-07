using POne.Core.CQRS;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Queries.Inputs.Notifications;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Business.QueryHandlers
{
    internal class NotificationQueryHandler : IQueryHandler<GetUnreadNotifications>
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationQueryHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<IQueryOutput> Handle(GetUnreadNotifications request, CancellationToken cancellationToken)
        {
            var notifications = await _notificationRepository
                .GetUnreadNotificationsAsync(request, cancellationToken);

            return QueryOutput.Ok(notifications);
        }
    }
}

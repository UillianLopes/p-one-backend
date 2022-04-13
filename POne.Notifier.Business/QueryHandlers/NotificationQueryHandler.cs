using POne.Core.CQRS;
using POne.Notifier.Domain.Contracts.Repositories;
using POne.Notifier.Domain.Queries.Inputs.Notifications;

namespace POne.Notifier.Business.QueryHandlers
{
    public class NotificationQueryHandler : IQueryHandler<GetUnreadNotifications>
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

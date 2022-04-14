using POne.Core.Contracts;
using POne.Core.CQRS;
using POne.Domain.Commands.Inputs;
using POne.Notifier.Domain.Commands.Inputs;
using POne.Notifier.Domain.Contracts.Facades;
using POne.Notifier.Domain.Contracts.Repositories;
using POne.Notifier.Domain.Entities;
using POne.Notifier.Domain.Queries.Outputs.Notifications;

namespace POne.Notifier.Business.CommandHandlers
{
    public class NotificationCommandHandler : ICommandHandler<CreateNotificationCommand>, ICommandHandler<MarkAllNotificationsAsReadCommand>
    {
        private readonly INotificationRepository _notificationRespository;
        private readonly INotificationsHubFacade _notificationsHubFacade;
        private readonly IAuthenticatedUser _authenticatedUser;

        public NotificationCommandHandler(INotificationRepository notificationRespository, INotificationsHubFacade notificationsHubFacade, IAuthenticatedUser authenticatedUser)
        {
            _notificationRespository = notificationRespository;
            _notificationsHubFacade = notificationsHubFacade;
            _authenticatedUser = authenticatedUser;
        }

        public async Task<ICommandOuput> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = new Notification(
                request.Title,
                request.Text,
                request.Type,
                request.Application,
                request.UserId
            );

            await _notificationRespository.CreateAync(notification, cancellationToken);

            if (request.UserId is Guid userId)
                await _notificationsHubFacade.NotificateAsync(userId.ToString(), request, cancellationToken);

            return CommandOutput.Created(notification.Id.ToString(), new NotificationOutput
            {
                Id = notification.Id,
                Creation = notification.Creation,
                Text = notification.Text,
                Title = notification.Title
            });

        }

        public async Task<ICommandOuput> Handle(MarkAllNotificationsAsReadCommand request, CancellationToken cancellationToken)
        {
            var unreadNotifications = await _notificationRespository
                .GetUnreadNotificationsAsync(cancellationToken);

            foreach (var unreadNotification in unreadNotifications)
                unreadNotification.MarkAsRead(_authenticatedUser.Id);

            return CommandOutput.Ok("All notifications marked as read, with success");
        }
    }
}

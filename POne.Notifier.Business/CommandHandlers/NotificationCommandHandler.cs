using POne.Core.CQRS;
using POne.Notifier.Domain.Commands.Inputs;
using POne.Notifier.Domain.Contracts.Repositories;
using POne.Notifier.Domain.Entities;
using POne.Notifier.Domain.Queries.Outputs.Notifications;

namespace POne.Notifier.Business.CommandHandlers
{
    public class NotificationCommandHandler : ICommandHandler<CreateNotificationCommand>
    {
        private readonly INotificationRepository _notificationRespository;

        public NotificationCommandHandler(INotificationRepository notificationRespository)
        {
            _notificationRespository = notificationRespository;
        }

        public async Task<ICommandOuput> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = new Notification(request.Title, request.Text, request.Type, request.Application, request.UserId);

            await _notificationRespository.CreateAync(notification, cancellationToken);

            return CommandOutput.Created(notification.Id.ToString(), new NotificationOutput
            {
                Id = notification.Id,
                Creation = notification.Creation,
                Text = notification.Text,
                Title = notification.Title
            });

        }
    }
}

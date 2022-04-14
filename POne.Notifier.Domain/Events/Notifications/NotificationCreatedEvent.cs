using POne.Core.CQRS;
using POne.Core.Enums;

namespace POne.Notifier.Domain.Events.Notifications
{
    public class NotificationCreatedEvent : IEvent
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public NotificationType Type { get; set; }
        public POneApplication Application { get; set; }
    }
}

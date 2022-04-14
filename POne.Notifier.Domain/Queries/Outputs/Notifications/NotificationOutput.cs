using POne.Core.Enums;

namespace POne.Notifier.Domain.Queries.Outputs.Notifications
{
    public class NotificationOutput
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public NotificationType Type { get; set; }
        public bool IsRead { get; set; }
        public DateTime Creation { get; set; }
    }
}

using POne.Core.Entities;

namespace POne.Notifier.Domain.Entities
{
    public class NotificationState : Entity
    {
        protected NotificationState() : base() { }

        public NotificationState(Notification notification, Guid userId, bool isRead) : this()
        {
            Notification = notification;
            UserId = userId;
            IsRead = isRead;
        }

        public virtual Notification Notification { get; private set; }
        public Guid UserId { get; private set; }
        public bool IsRead { get; private set; }

        public void MarkAsRead() => IsRead = true;

        public void MarkAsUnread() => IsRead = false;
    }
}

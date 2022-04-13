using POne.Core.Entities;
using POne.Core.Enums;

namespace POne.Notifier.Domain.Entities
{
    public class Notification : Entity
    {
        protected Notification() : base()
        {
            Title = string.Empty;
            Text = string.Empty;
            NotificationStates = new HashSet<NotificationState>();
        }

        public Notification(string title, string text, NotificationType type, POneApplication application, Guid? userId)
        {
            Title = title;
            Text = text;
            Type = type;
            Application = application;
            UserId = userId;
        }

        public string Title { get; private set; }
        public string Text { get; private set; }
        public NotificationType Type { get; private set; }
        public POneApplication Application { get; private set; }
        public Guid? UserId { get; private set; }
        public virtual ISet<NotificationState> NotificationStates { get; }

        public void MarkAsRead(Guid userId)
        {
            if (NotificationStates.FirstOrDefault(e => e.UserId == userId) is not NotificationState notificationState)
            {
                NotificationStates.Add(new NotificationState(this, userId, true));
                return;
            }

            notificationState.MarkAsRead();
        }

        public void MarkAsUnread(Guid userId)
        {
            if (NotificationStates.FirstOrDefault(e => e.UserId == userId) is not NotificationState notificationState)
            {
                NotificationStates.Add(new NotificationState(this, userId, false));
                return;
            }

            notificationState.MarkAsUnread();
        }


    }
}

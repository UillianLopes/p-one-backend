using POne.Core.Entities;
using POne.Core.Enums;
using System;

namespace POne.Financial.Domain.Entities
{
    public class Notification : Entity
    {
        protected Notification() { }

        public Notification(string title, string text, NotificationType type, Guid userId)
        {
            Title = title;
            Text = text;
            Type = type;
            UserId = userId;
            IsRead = false;
        }

        public string Title { get; private set; }
        public string Text { get; private set; }
        public NotificationType Type { get; private set; }
        public bool IsRead { get; private set; }
        public Guid UserId { get; private set; }

        public void MarkAsRead() => IsRead = true;

        public void MarkAsUnread() => IsRead = false;
    }
}

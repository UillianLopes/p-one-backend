using POne.Core.Enums;
using System;

namespace POne.Core.Models
{
    public class NotificationModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public NotificationType Type { get; set; }
        public bool IsRead { get; set; }
        public DateTime Creation { get; set; }
    }
}

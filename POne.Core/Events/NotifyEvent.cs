using POne.Core.CQRS;
using POne.Core.Enums;

namespace POne.Core.Events
{
    public record NotifyEvent : IEvent
    {
        public NotifyEvent(string title, string text, NotificationType type)
        {
            Title = title;
            Text = text;
            Type = type;
        }

        public string Title { get; set; }
        public string Text { get; set; }
        public NotificationType Type { get; set; }

        public static NotifyEvent Success(string title, string text) => new(title, text, NotificationType.Success);
        public static NotifyEvent Information(string title, string text) => new(title, text, NotificationType.Information);
        public static NotifyEvent Error(string title, string text) => new(title, text, NotificationType.Error);
        public static NotifyEvent Warning(string title, string text) => new(title, text, NotificationType.Warning);
    }
}

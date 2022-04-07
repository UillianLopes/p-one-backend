using POne.Core.CQRS;
using POne.Core.Enums;
using System;

namespace POne.Financial.Domain.Events
{
    public record NotifyEvent : IEvent
    {
        protected NotifyEvent() { }

        public NotifyEvent(string title, string text, NotificationType type, Guid? id) : base()
        {
            Title = title;
            Text = text;
            Type = type;
            Id = id;
        }

        public string Title { get; set; }
        public string Text { get; set; }
        public NotificationType Type { get; set; }
        public Guid? Id { get; set; }

        public static NotifyEvent Success(string title, string text) => new(title, text, NotificationType.Success, null);
        public static NotifyEvent Information(string title, string text) => new(title, text, NotificationType.Information, null);
        public static NotifyEvent Error(string title, string text) => new(title, text, NotificationType.Error, null);
        public static NotifyEvent Warning(string title, string text) => new(title, text, NotificationType.Warning, null);
    }
}

using POne.Core.CQRS;
using POne.Core.Enums;
using System;

namespace POne.Domain.Commands.Inputs
{
    public class CreateNotificationCommand : ICommand
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid? UserId { get; set; }
        public Guid? AccountId { get; set; }
        public NotificationType Type { get; set; }
        public POneApplication Application { get; set; }
    }
}

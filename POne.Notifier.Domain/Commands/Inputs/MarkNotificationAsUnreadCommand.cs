using POne.Core.CQRS;

namespace POne.Notifier.Domain.Commands.Inputs
{
    public class MarkNotificationAsUnreadCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}

using POne.Core.CQRS;

namespace POne.Notifier.Domain.Commands.Inputs
{
    public class MarkNotificationAsReadCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}

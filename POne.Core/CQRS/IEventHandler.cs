using MediatR;

namespace POne.Core.CQRS
{
    public interface IEventHandler<T> : INotificationHandler<T> where T : IEvent
    {
    }
}

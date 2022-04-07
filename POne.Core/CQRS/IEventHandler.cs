using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Core.CQRS
{
    public interface IEventHandler<T> : INotificationHandler<T> where T : IEvent
    {
        Task Handle(T command, CancellationToken cancellationToken);
    }
}

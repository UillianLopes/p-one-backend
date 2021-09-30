using System.Threading;
using System.Threading.Tasks;

namespace POne.Core.CQRS
{
    public interface IEventHandler<T> where T : IEvent
    {
        Task HandleAsync(T command, CancellationToken cancellationToken);
    }
}

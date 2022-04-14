using POne.Domain.Commands.Inputs;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Domain.Contracts.Facades
{
    public interface INotifierApiFacade
    {
        Task NotifyAsync(CreateNotificationCommand command, CancellationToken cancellationToken);
    }
}

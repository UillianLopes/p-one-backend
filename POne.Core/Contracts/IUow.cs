using System.Threading;
using System.Threading.Tasks;

namespace POne.Core.Contracts
{
    public interface IUow
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}

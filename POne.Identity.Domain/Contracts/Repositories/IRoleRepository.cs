using POne.Identity.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Domain.Contracts.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> FindByKeyAsync(string key, CancellationToken cancellationToken);
    }
}

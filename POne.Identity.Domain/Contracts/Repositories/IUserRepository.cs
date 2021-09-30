using POne.Core.Contracts;
using POne.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Domain.Contracts.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByEmail(string email, CancellationToken cancellationToken);
    }
}

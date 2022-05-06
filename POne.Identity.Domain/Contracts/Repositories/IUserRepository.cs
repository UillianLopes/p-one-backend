using POne.Core.Contracts;
using POne.Identity.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Domain.Contracts.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByEmail(string email, CancellationToken cancellationToken);

        Task<UserSettings> GetUserSettingsAsync(Guid id, CancellationToken cancellationToken);
    }
}

using POne.Core.Contracts;
using POne.Identity.Domain.Entities;
using POne.Identity.Domain.Queries.Inputs.Users;
using POne.Identity.Domain.Queries.Outputs.Users;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Domain.Contracts.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByEmail(string email, CancellationToken cancellationToken);

        Task<UserSettings> GetUserSettingsAsync(Guid id, CancellationToken cancellationToken);

        Task<List<UserOutput>> GetAllUsersAsync(GetAllUsers filter, CancellationToken cancellationToken);

        Task<int> GetAllUsersAmmountAsync(GetAllUsers filter, CancellationToken cancellationToken);
    }
}

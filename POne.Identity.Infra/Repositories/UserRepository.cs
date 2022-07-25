using Microsoft.EntityFrameworkCore;
using POne.Core.Contracts;
using POne.Core.Models;
using POne.Identity.Domain.Contracts.Repositories;
using POne.Identity.Domain.Entities;
using POne.Identity.Domain.Queries.Inputs.Users;
using POne.Identity.Domain.Queries.Outputs.Users;
using POne.Identity.Infra.Connections;
using POne.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Infra.Repositories
{
    public class UserRepository : Repository<POneIdentityDbContext, User>, IUserRepository
    {

        private readonly IAuthenticatedUser _authenticatedUser;
        public UserRepository(IAuthenticatedUser authenticatedUser, POneIdentityDbContext dbContext) : base(dbContext)
        {
            _authenticatedUser = authenticatedUser;
        }

        public Task<User> FindByEmail(string email, CancellationToken cancellationToken) => _dbContext
            .Set<User>()
            .FirstOrDefaultAsync(user => user.Email == email, cancellationToken);

        private IQueryable<User> GetAllUsersQuery(GetAllUsers filter)
        {
            var query = _dbContext
                .Users
                .Where((user) => !user.IsDeleted && _authenticatedUser.AccountId == user.Account.Id);


            if (filter.Text is string text && !string.IsNullOrEmpty(text))
                query = query.Where(user => EF.Functions.Like(user.Name, $"{text}%") || EF.Functions.Like(user.Email, $"{text}%") || EF.Functions.Like(user.Profile.Name, $"{text}%"));

            return query;
        }

        public Task<int> GetAllUsersAmmountAsync(GetAllUsers query, CancellationToken cancellationToken) => GetAllUsersQuery(query).CountAsync(cancellationToken);

        public Task<List<UserOutput>> GetAllUsersAsync(GetAllUsers query, CancellationToken cancellationToken)
        {
            return GetAllUsersQuery(query)
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .Select((user) => new UserOutput
                {
                    Name = user.Name,
                    Email = user.Email,
                    BirthDate = user.BirthDate,
                    Profile = new OptionModel
                    {
                        Id = user.Profile.Id,
                        Title = user.Profile.Name
                    },
                })
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public Task<UserSettings> GetUserSettingsAsync(Guid id, CancellationToken cancellationToken) => _dbContext
            .Set<User>()
            .Where(u => u.Id == id)
            .Select(u => u.Settings)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }
}

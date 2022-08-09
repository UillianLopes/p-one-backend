using Microsoft.EntityFrameworkCore;
using POne.Core.Contracts;
using POne.Core.Models;
using POne.Identity.Domain.Contracts.Repositories;
using POne.Identity.Domain.Entities;
using POne.Identity.Domain.Queries.Inputs.Profiles;
using POne.Identity.Domain.Queries.Outputs.Profiles;
using POne.Identity.Infra.Connections;
using POne.Infra.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Infra.Repositories
{
    public class ProfileRepository : Repository<POneIdentityDbContext, Profile>, IProfileRepository
    {
        private readonly IAuthenticatedUser _authenticatedUser;
        public ProfileRepository(POneIdentityDbContext dbContext, IAuthenticatedUser authenticatedUser) : base(dbContext)
        {
            _authenticatedUser = authenticatedUser;
        }

        public Task<List<OptionModel>> GetAllAsOptionsAsync(GetAllProfilesAsOptions query, CancellationToken cancellationToken) => _dbContext
            .Profiles
            .Where((profile) => profile.IsDefault || (profile.Account != null && profile.Account.Id == _authenticatedUser.Id))
            .Select((profile) => new OptionModel { Id = profile.Id, Title = profile.Name })
            .ToListAsync(cancellationToken);

        public Task<List<ProfileOutput>> GetAllAsync(GetAllProfiles query, CancellationToken cancellationToken)
        {
            var profilesQuery = _dbContext
                .Profiles
                .Where(profile => profile.IsDefault || (profile.Account != null && profile.Account.Id == _authenticatedUser.Id));

            if (query.Name is string name)
                profilesQuery = profilesQuery
                    .Where((profile) => EF.Functions.Like(profile.Name, $"{name}%"));

            return profilesQuery
                .OrderBy(profile => profile.Name)
                .Select((profile) => new ProfileOutput
                {
                    Description = profile.Description,
                    Name = profile.Name,
                    Id = profile.Id,
                    Roles = profile
                        .Roles
                        .Select(role => role.Key)
                        .ToArray()
                }).ToListAsync(cancellationToken);
        }

    }
}

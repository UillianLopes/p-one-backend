using POne.Core.Auth;
using POne.Core.CQRS;
using POne.Identity.Domain.Contracts.Repositories;
using POne.Identity.Domain.Entities;
using POne.Identity.Domain.Queries.Inputs.Profiles;
using POne.Identity.Domain.Queries.Outputs.Profiles;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace POne.Identity.Business.QueryHandlers
{
    public class ProfileQueryHandler : IQueryHandler<GetAllProfiles>, IQueryHandler<GetAllRoles>, IQueryHandler<GetAllProfilesAsOptions>, IQueryHandler<GetProfileById>
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileQueryHandler(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<IQueryOutput> Handle(GetAllProfiles request, CancellationToken cancellationToken)
        {
            var profiles = await _profileRepository
                .GetAllAsync(request, cancellationToken);

            return QueryOutput.Ok(profiles);
        }

        public async Task<IQueryOutput> Handle(GetAllRoles request, CancellationToken cancellationToken)
        {
            if (await _profileRepository.FindByIdAync(request.ProfileId, cancellationToken) is not Profile profile)
                return QueryOutput.NotFound("PROFILE_NOT_FOUND");

            var appsModulesAndRoles = RolesUtils
                .ReadAppsAndRoles()
                .Select((role) => new
                {
                    role.Title,
                    role.Description,
                    Modules = role
                        .Modules
                        .Select((module) => new
                        {
                            module.Title,
                            module.Description,
                            Roles = module.Roles.Select((role) => new
                            {
                                role.Title,
                                role.Description,
                                role.Key,
                            })
                        })
                }).ToList();

            return QueryOutput.Ok(appsModulesAndRoles);
        }

        public async Task<IQueryOutput> Handle(GetAllProfilesAsOptions request, CancellationToken cancellationToken)
        {
            var profilesAsOptions = await _profileRepository
                .GetAllAsOptionsAsync(request, cancellationToken);

            return QueryOutput.Ok(profilesAsOptions);
        }

        public async Task<IQueryOutput> Handle(GetProfileById request, CancellationToken cancellationToken)
        {
            var profile = await _profileRepository.FindByIdAync(request.Id, cancellationToken);

            return QueryOutput.Ok(new ProfileOutput
            {
                Id = profile.Id,
                Description = profile.Description,
                IsDefault = profile.IsDefault,
                Name = profile.Name,
                Roles = profile.Roles.Select(e => e.Key).ToArray()
            });
        }
    }
}

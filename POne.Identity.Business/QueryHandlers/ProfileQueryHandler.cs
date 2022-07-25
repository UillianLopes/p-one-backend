using POne.Core.Auth;
using POne.Core.CQRS;
using POne.Identity.Domain.Contracts.Repositories;
using POne.Identity.Domain.Entities;
using POne.Identity.Domain.Queries.Inputs.Profiles;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace POne.Identity.Business.QueryHandlers
{
    public class ProfileQueryHandler : IQueryHandler<GetAllProfiles>, IQueryHandler<GetAllRoles>
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

            var profileRoles = profile
                .Roles
                .Select((role) => role.Key)
                .ToArray();

            var appsModulesAndRoles = RolesUtils
                .ReadAppsAndRoles()
                .Select((role) => new
                {
                    role.Title,
                    role.Description,
                    Modules = role.Modules
                        .Select((module) => new
                        {
                            module.Title,
                            module.Description,
                            Roles = module.Roles.Select((role) => new
                            {
                                role.Title,
                                role.Description,
                                role.Key,
                                IsActive = profileRoles.Contains(role.Key)
                            })
                        })
                }).ToList();

            return QueryOutput.Ok(appsModulesAndRoles);
        }
    }
}

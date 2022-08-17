using POne.Core.CQRS;
using POne.Identity.Business.Commands.Inputs.Profiles;
using POne.Identity.Domain.Contracts.Repositories;
using POne.Identity.Domain.Entities;
using POne.Identity.Domain.Queries.Outputs.Profiles;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Business.CommandHandlers
{
    public class ProfileCommandHandler : ICommandHandler<ToggleRoleCommand>, ICommandHandler<CreateProfileCommand>, ICommandHandler<UpdateProfileCommand>, ICommandHandler<AddRoleCommand>, ICommandHandler<RemoveRoleCommand>
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IRoleRepository _roleRepository;

        public ProfileCommandHandler(IProfileRepository profileRepository, IRoleRepository roleRepository)
        {
            _profileRepository = profileRepository;
            _roleRepository = roleRepository;
        }

        public async Task<ICommandOuput> Handle(ToggleRoleCommand request, CancellationToken cancellationToken)
        {
            if (await _profileRepository.FindByIdAync(request.ProfileId, cancellationToken) is not Profile profile)
                return CommandOutput.NotFound("@PONE.MESSAGES.PROFILE_NOT_FOUND");

            if (await _roleRepository.FindByKeyAsync(request.Key, cancellationToken) is not Role role)
                return CommandOutput.NotFound("@PONE.MESSAGES.ROLE_NOT_FOUND");

            profile.Toggle(role);

            return CommandOutput.Ok("@PONE.MESSAGES.ROLE_TOGGLED_WITH_SUCCESS");


        }

        public async Task<ICommandOuput> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = new Profile(request.Name, request.Description);

            await _profileRepository.CreateAync(profile, cancellationToken);

            return CommandOutput.Ok(new ProfileOutput
            {
                Id = profile.Id,
                Name = profile.Name,
                Description = profile.Description
            });

        }

        public Task<ICommandOuput> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ICommandOuput> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            if (await _profileRepository.FindByIdAync(request.ProfileId, cancellationToken) is not Profile profile)
                return CommandOutput.NotFound("@PONE.MESSAGES.PROFILE_NOT_FOUND");

            if (await _roleRepository.FindByKeyAsync(request.Key, cancellationToken) is not Role role)
                return CommandOutput.NotFound("@PONE.MESSAGES.ROLE_NOT_FOUND");

            profile.Add(role);

            return CommandOutput.Ok("@PONE.MESSAGES.ROLED_ADDED");
        }

        public async Task<ICommandOuput> Handle(RemoveRoleCommand request, CancellationToken cancellationToken)
        {
            if (await _profileRepository.FindByIdAync(request.ProfileId, cancellationToken) is not Profile profile)
                return CommandOutput.NotFound("@PONE.MESSAGES.PROFILE_NOT_FOUND");

            if (await _roleRepository.FindByKeyAsync(request.Key, cancellationToken) is not Role role)
                return CommandOutput.NotFound("@PONE.MESSAGES.ROLE_NOT_FOUND");

            profile.Remove(role);

            return CommandOutput.Ok("@PONE.MESSAGES.ROLE_REMOVED");
        }
    }
}

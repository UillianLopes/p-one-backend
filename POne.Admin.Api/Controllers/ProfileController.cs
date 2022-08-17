using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POne.Core.Auth;
using POne.Core.Contracts;
using POne.Core.Mvc;
using POne.Identity.Business.Commands.Inputs.Profiles;
using POne.Identity.Domain.Queries.Inputs.Profiles;

namespace POne.Admin.Api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class ProfileController : BaseController
    {
        public ProfileController(IMediator mediator, IUow uow) : base(mediator, uow)
        {
        }

        [HttpGet("[action]")]
        [Authorize(Roles = Roles.Admin.Profile.Read)]
        public Task<IActionResult> GetAllAsOptionsAsync([FromQuery] GetAllProfilesAsOptions query, CancellationToken cancellationToken) => QueryAsync(query, cancellationToken);

        [HttpPost]
        [Authorize(Roles = Roles.Admin.Profile.Create)]
        public Task<IActionResult> CreateAsync([FromBody] CreateProfileCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpPut("{profileId}")]
        [Authorize(Roles = Roles.Admin.Profile.Update)]
        public Task<IActionResult> UpdateAsync([FromRoute] Guid profileId, [FromBody] UpdateProfileCommand command, CancellationToken cancellationToken)
        {
            command.Id = profileId;
            return SendAsync(command, cancellationToken);
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin.Profile.Read)]
        public Task<IActionResult> GetAllAsync([FromQuery] GetAllProfiles query, CancellationToken cancellationToken) => QueryAsync(query, cancellationToken);

        [HttpGet("{profileId}/[action]")]
        [Authorize(Roles = Roles.Admin.Profile.Read)]
        public Task<IActionResult> GetApplicationsAndRoles([FromRoute] Guid profileId, CancellationToken cancellationToken) => QueryAsync(new GetAllRoles(profileId), cancellationToken);

        [HttpGet("{profileId}")]
        [Authorize(Roles = Roles.Admin.Profile.Read)]
        public Task<IActionResult> GetByIdAsync([FromRoute] Guid profileId, CancellationToken cancellationToken) => QueryAsync(new GetProfileById(profileId), cancellationToken);

        [HttpPut("{profileId}/[action]")]
        [Authorize(Roles = Roles.Admin.Profile.Update)]
        public Task<IActionResult> AddRoleAsync([FromRoute] Guid profileId, [FromBody] AddRoleCommand command, CancellationToken cancellationToken)
        {
            command.ProfileId = profileId;
            return SendAsync(command, cancellationToken);
        }

        [HttpPut("{profileId}/[action]")]
        [Authorize(Roles = Roles.Admin.Profile.Update)]
        public Task<IActionResult> RemoveRoleAsync([FromRoute] Guid profileId, [FromBody] RemoveRoleCommand command, CancellationToken cancellationToken)
        {
            command.ProfileId = profileId;
            return SendAsync(command, cancellationToken);
        }

    }
}

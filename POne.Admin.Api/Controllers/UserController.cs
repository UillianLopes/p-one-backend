using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POne.Api.Auth;
using POne.Core.Auth;
using POne.Core.Contracts;
using POne.Core.Mvc;
using POne.Identity.Business.Commands.Inputs.Users;
using POne.Identity.Domain.Queries.Inputs.Users;

namespace POne.Admin.Api.Controllers
{
    [Route("[controller]")]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator, IUow uow) : base(mediator, uow) { }

        [HttpGet]
        [Authorize(Roles = Roles.Admin.User.Read)]
        public Task<IActionResult> GetAllAsync([FromQuery] GetAllUsers query, CancellationToken cancellationToken) => QueryAsync(query, cancellationToken);

        [HttpPost("[action]")]
        public Task<IActionResult> CreateStandaloneAsync([FromBody] CreateStandaloneUserCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpPost]
        [Authorize(Roles = Roles.Admin.User.Create)]
        public Task<IActionResult> CreateAsync([FromBody] CreateUserCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Admin.User.Update)]
        public Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateUserCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            return SendAsync(command, cancellationToken);
        }

        [HttpPut("[action]")]
        [POneAuthorize(Roles.Admin.User.Update)]
        public Task<IActionResult> SettingsAsync([FromBody] UpdateUserSettingsCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpGet("[action]/{id}")]
        [POneAuthorize(Roles.Admin.User.Read)]
        public Task<IActionResult> SettingsAsync([FromRoute] GetUserSettings query, CancellationToken cancellationToken) => QueryAsync(query, cancellationToken);

        [HttpGet("[action]")]
        [POneAuthorize(Roles.Admin.User.Read)]
        public Task<IActionResult> SettingsAsync(CancellationToken cancellationToken) => QueryAsync(new GetAuthenticatedUserSettings(), cancellationToken);
    }
}

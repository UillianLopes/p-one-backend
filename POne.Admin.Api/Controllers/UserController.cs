using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public Task<IActionResult> CreateAsync([FromBody] CreateUserCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpPut("{id}")]
        [Authorize]
        public Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateUserCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;

            return SendAsync(command, cancellationToken);
        }


        [HttpPut("[action]")]
        [Authorize]
        public Task<IActionResult> SettingsAsync([FromBody] UpdateUserSettingsCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);


        [HttpGet("[action]/{id}")]
        [Authorize]
        public Task<IActionResult> SettingsAsync([FromRoute] GetUserSettings query, CancellationToken cancellationToken) => QueryAsync(query, cancellationToken);

        [HttpGet("[action]")]
        [Authorize]
        public Task<IActionResult> SettingsAsync(CancellationToken cancellationToken) => QueryAsync(new GetAuthenticatedUserSettings(), cancellationToken);
    }
}

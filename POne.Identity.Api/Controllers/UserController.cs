using MediatR;
using Microsoft.AspNetCore.Mvc;
using POne.Core.Contracts;
using POne.Core.Mvc;
using POne.Identity.Business.Commands.Inputs.Users;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Api.Controllers
{
    [Route("[controller]")]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator, IUow uow) : base(mediator, uow) { }

        [HttpPost]
        public Task<IActionResult> CreateAsync([FromBody] CreateUserCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpPut]
        public Task<IActionResult> UpdateAsync([FromBody] UpdateUserCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);
    }
}

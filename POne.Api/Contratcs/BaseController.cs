using MediatR;
using Microsoft.AspNetCore.Mvc;
using POne.Core.Contracts;
using POne.Core.CQRS;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Core.Mvc
{
    public abstract class BaseController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IUow _uow;

        protected BaseController(IMediator mediator, IUow uow)
        {
            _mediator = mediator;
            _uow = uow;
        }

        public async Task<IActionResult> SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand
        {
            var output = await _mediator
                .Send(command, cancellationToken);

            if (output.Success)
                await _uow.SaveChangesAsync(cancellationToken);

            return output.HttpStatusCode switch
            {
                HttpStatusCode.OK => Ok(output),
                HttpStatusCode.BadRequest => BadRequest(output),
                HttpStatusCode.NotFound => NotFound(output),
                HttpStatusCode.Created => Created(output.Uri, output),
                _ => Ok(output),
            };
        }
    }
}

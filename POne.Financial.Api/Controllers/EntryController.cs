using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POne.Core.Contracts;
using POne.Core.Mvc;
using POne.Financial.Domain.Commands.Inputs.Entries;
using POne.Financial.Domain.Queries.Inputs.Entries;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class EntryController : BaseController
    {
        public EntryController(IMediator mediator, IUow uow) : base(mediator, uow)
        {
        }

        [HttpPost]
        public Task<IActionResult> CreateAsync([FromBody] CreateEntryCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpPost("[action]")]
        public Task<IActionResult> ProccessRecurrenceAsync([FromBody] ProccessEntryRecurrenceCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpDelete("{Id}")]
        public Task<IActionResult> DeleteAsync([FromRoute] DeleteEntryCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpDelete]
        public Task<IActionResult> DeleteAsync([FromQuery] DeleteEntriesCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpGet]
        public Task<IActionResult> GetAllAsync([FromQuery] GetFiltredEntries query, CancellationToken cancellationToken) => QueryAsync(query, cancellationToken);
    }
}

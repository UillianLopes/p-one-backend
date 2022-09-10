using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POne.Api.Auth;
using POne.Core.Auth;
using POne.Core.Contracts;
using POne.Core.Mvc;
using POne.Financial.Domain.Commands.Inputs.Entries;
using POne.Financial.Domain.Queries.Inputs.Entries;
using System;
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
        [POneAuthorize(Roles.Financial.Entry.Create)]
        public Task<IActionResult> CreateStandardEntryAsync([FromBody] CreateStandardEntryCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpPost("[action]")]
        [POneAuthorize(Roles.Financial.Entry.Create)]
        public Task<IActionResult> CreateInstallmentEntriesAsync([FromBody] CreateInstallmentEntriesCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpPost("[action]")]
        [POneAuthorize(Roles.Financial.Entry.Create)]
        public Task<IActionResult> CreateRecurrentEntryAsync([FromBody] CreateRecurrentEntryCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpPost("[action]")]
        [POneAuthorize(Roles.Financial.Entry.Create)]
        public Task<IActionResult> BuildEntryRecurrenceAsync([FromBody] CreatEntryInstallments command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpPut("{Id}/[action]")]
        [POneAuthorize(Roles.Financial.Entry.Update)]
        public Task<IActionResult> PayAsync([FromRoute] Guid id, [FromBody] PayEntryCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            return SendAsync(command, cancellationToken);
        }

        [HttpPut("{Id}")]
        [POneAuthorize(Roles.Financial.Entry.Update)]
        public Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateEntryCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            return SendAsync(command, cancellationToken);
        }

        [HttpDelete("{Id}")]
        [POneAuthorize(Roles.Financial.Entry.Delete)]
        public Task<IActionResult> DeleteAsync([FromRoute] DeleteEntryCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpDelete]
        [POneAuthorize(Roles.Financial.Entry.Delete)]
        public Task<IActionResult> DeleteAsync([FromQuery] DeleteEntriesCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpGet]
        [POneAuthorize(Roles.Financial.Entry.Read)]
        public Task<IActionResult> GetAllAsync([FromQuery] GetFiltredEntries query, CancellationToken cancellationToken) => QueryAsync(query, cancellationToken);
    }
}

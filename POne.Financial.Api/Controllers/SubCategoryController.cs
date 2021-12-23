using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POne.Core.Contracts;
using POne.Core.Mvc;
using POne.Financial.Domain.Commands.Inputs.SubCategories;
using POne.Financial.Domain.Queries.Inputs.SubCategories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Api.Controllers
{

    [Route("[controller]")]
    [Authorize]
    public class SubCategoryController : BaseController
    {
        public SubCategoryController(IMediator mediator, IUow uow) : base(mediator, uow)
        {
        }

        [HttpPost]
        public Task<IActionResult> CreateAsync([FromBody] CreateSubCategoryCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpPut("{Id}")]
        public Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateSubCategoryCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            return SendAsync(command, cancellationToken);
        }

        [HttpDelete("{Id}")]
        public Task<IActionResult> DeleteAsync([FromRoute] DeleteSubCategoryCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpDelete]
        public Task<IActionResult> DeleteAsync([FromQuery] DeleteSubCategoriesCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpGet]
        public Task<IActionResult> GetAllAsync([FromQuery] GetAllSubCategories query, CancellationToken cancellationToken) => QueryAsync(query, cancellationToken);
    }
}

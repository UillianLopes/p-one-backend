using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POne.Core.Contracts;
using POne.Core.Mvc;
using POne.Financial.Domain.Commands.Inputs.Categories;
using POne.Financial.Domain.Queries.Inputs.Categories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Api.Controllers
{

    [Route("[controller]")]
    [Authorize]
    public class CategoryController : BaseController
    {
        public CategoryController(IMediator mediator, IUow uow) : base(mediator, uow)
        {
        }

        [HttpPost]
        public Task<IActionResult> CreateAsync([FromBody] CreateCategoryCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpPut("{Id}")]
        public Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            return SendAsync(command, cancellationToken);
        }

        [HttpDelete("{Id}")]
        public Task<IActionResult> DeleteAsync([FromRoute] DeleteCategoryCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpDelete]
        public Task<IActionResult> DeleteAsync([FromQuery] DeleteCategoriesCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpGet]
        public Task<IActionResult> GetAllAsync([FromQuery] GetAllCategories query, CancellationToken cancellationToken) => QueryAsync(query, cancellationToken);

    }
}

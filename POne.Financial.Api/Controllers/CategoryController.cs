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
    public class CategoryController : BaseController
    {
        public CategoryController(IMediator mediator, IUow uow) : base(mediator, uow)
        {
        }

        [HttpPost]
        [Authorize("category_create")]
        public Task<IActionResult> CreateAsync([FromBody] CreateCategoryCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpPut("{Id}")]
        [Authorize("category_update")]
        public Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            return SendAsync(command, cancellationToken);
        }

        [HttpDelete("{Id}")]
        [Authorize("category_delete")]
        public Task<IActionResult> DeleteAsync([FromRoute] DeleteCategoryCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [Authorize("category_delete")]
        [HttpDelete]
        public Task<IActionResult> DeleteAsync([FromQuery] DeleteCategoriesCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpGet]
        [Authorize("category_read")]
        public Task<IActionResult> GetAllAsync([FromQuery] GetAllCategories query, CancellationToken cancellationToken) => QueryAsync(query, cancellationToken);

    }
}

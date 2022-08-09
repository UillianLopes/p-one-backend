using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POne.Api.Auth;
using POne.Core.Auth;
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

        [HttpGet("[action]")]
        [POneAuthorize(Roles.Financial.Category.Read)]
        public Task<IActionResult> GetAllAsOptionsAsync([FromQuery] GetAllCategoriesAsOptions query, CancellationToken cancellationToken) => QueryAsync(query, cancellationToken);

        [HttpPost]
        [POneAuthorize(Roles.Financial.Category.Create)]
        public Task<IActionResult> CreateAsync([FromBody] CreateCategoryCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpPut("{Id}")]
        [POneAuthorize(Roles.Financial.Category.Update)]
        public Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            return SendAsync(command, cancellationToken);
        }

        [HttpDelete("{Id}")]
        [POneAuthorize(Roles.Financial.Category.Read)]
        public Task<IActionResult> DeleteAsync([FromRoute] DeleteCategoryCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpDelete]
        [POneAuthorize(Roles.Financial.Category.Delete)]
        public Task<IActionResult> DeleteAsync([FromQuery] DeleteCategoriesCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpGet]
        [POneAuthorize(Roles.Financial.Category.Read)]
        public Task<IActionResult> GetAllAsync([FromQuery] GetAllCategories query, CancellationToken cancellationToken) => QueryAsync(query, cancellationToken);

    }
}

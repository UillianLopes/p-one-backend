using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POne.Api.Auth;
using POne.Core.Auth;
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

        [HttpGet("[action]")]
        [POneAuthorize(Roles.Financial.SubCategory.Read)]
        public Task<IActionResult> GetAllAsOptionsAsync([FromQuery] GetAllSubCategoriesAsOptions query, CancellationToken cancellationToken) => QueryAsync(query, cancellationToken);

        [HttpPost]
        [POneAuthorize(Roles.Financial.SubCategory.Create)]
        public Task<IActionResult> CreateAsync([FromBody] CreateSubCategoryCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);


        [HttpPut("{Id}")]
        [POneAuthorize(Roles.Financial.SubCategory.Update)]
        public Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateSubCategoryCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            return SendAsync(command, cancellationToken);
        }

        [HttpDelete("{Id}")]
        [POneAuthorize(Roles.Financial.SubCategory.Delete)]
        public Task<IActionResult> DeleteAsync([FromRoute] DeleteSubCategoryCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpDelete]
        [POneAuthorize(Roles.Financial.SubCategory.Delete)]
        public Task<IActionResult> DeleteAsync([FromQuery] DeleteSubCategoriesCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpGet]
        [POneAuthorize(Roles.Financial.SubCategory.Read)]
        public Task<IActionResult> GetAllAsync([FromQuery] GetAllSubCategories query, CancellationToken cancellationToken) => QueryAsync(query, cancellationToken);
    }
}

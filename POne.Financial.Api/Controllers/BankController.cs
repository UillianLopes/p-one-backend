﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POne.Api.Auth;
using POne.Core.Auth;
using POne.Core.Contracts;
using POne.Core.Mvc;
using POne.Financial.Domain.Queries.Inputs.Banks;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class BankController : BaseController
    {
        public BankController(IMediator mediator, IUow uow) : base(mediator, uow)
        {
        }

        [HttpGet]
        [POneAuthorize(Roles.Financial.Bank.Read)]
        public Task<IActionResult> GetAllAsync(CancellationToken cancellationToken) => QueryAsync(new GetAllBanks(), cancellationToken);
    }
}

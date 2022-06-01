using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POne.Core.Contracts;
using POne.Core.Mvc;
using POne.Financial.Domain.Commands.Inputs.Wallets;
using POne.Financial.Domain.Queries.Inputs.Wallets;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class WalletController : BaseController
    {
        public WalletController(IMediator mediator, IUow uow) : base(mediator, uow)
        {
        }

        [HttpPost]
        public Task<IActionResult> CreateAsync([FromBody] CreateWalletCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpPut("{Id}")]
        public Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateWalletCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            return SendAsync(command, cancellationToken);
        }

        [HttpDelete("{Id}")]
        public Task<IActionResult> DeleteAsync([FromRoute] DeleteWalletCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpDelete]
        public Task<IActionResult> DeleteAsync([FromQuery] DeleteWalletsCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpPut("{walletId}/[action]")]
        public Task<IActionResult> DepositAsync([FromRoute] Guid walletId, [FromBody] DepositCommand command, CancellationToken cancellationToken)
        {
            command.WalletId = walletId;
            return SendAsync(command, cancellationToken);
        }

        [HttpPut("{walletId}/[action]")]
        public Task<IActionResult> WithdrawAsync([FromRoute] Guid walletId, [FromBody] WithdrawCommand command, CancellationToken cancellationToken)
        {
            command.WalletId = walletId;
            return SendAsync(command, cancellationToken);
        }

        [HttpPut("[action]")]
        public Task<IActionResult> TransferAsync([FromBody] TransferCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpGet]
        public Task<IActionResult> GetAllAsync(CancellationToken cancellationToken) => QueryAsync(new GetAllWallets(), cancellationToken);
    }
}

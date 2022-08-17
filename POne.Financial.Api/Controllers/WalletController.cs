using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POne.Api.Auth;
using POne.Core.Auth;
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
        [POneAuthorize(Roles.Financial.Wallet.Create)]
        public Task<IActionResult> CreateAsync([FromBody] CreateWalletCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpPut("{Id}")]
        [POneAuthorize(Roles.Financial.Wallet.Update)]
        public Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateWalletCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            return SendAsync(command, cancellationToken);
        }

        [HttpDelete("{Id}")]
        [POneAuthorize(Roles.Financial.Wallet.Delete)]
        public Task<IActionResult> DeleteAsync([FromRoute] DeleteWalletCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpDelete]
        [POneAuthorize(Roles.Financial.Wallet.Delete)]
        public Task<IActionResult> DeleteAsync([FromQuery] DeleteWalletsCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpPut("{walletId}/[action]")]
        [POneAuthorize(Roles.Financial.Wallet.Update)]
        public Task<IActionResult> DepositAsync([FromRoute] Guid walletId, [FromBody] DepositCommand command, CancellationToken cancellationToken)
        {
            command.WalletId = walletId;
            return SendAsync(command, cancellationToken);
        }

        [HttpPut("{walletId}/[action]")]
        [POneAuthorize(Roles.Financial.Wallet.Update)]
        public Task<IActionResult> WithdrawAsync([FromRoute] Guid walletId, [FromBody] WithdrawCommand command, CancellationToken cancellationToken)
        {
            command.WalletId = walletId;
            return SendAsync(command, cancellationToken);
        }

        [HttpPut("[action]")]
        [POneAuthorize(Roles.Financial.Wallet.Update)]
        public Task<IActionResult> TransferAsync([FromBody] TransferCommand command, CancellationToken cancellationToken) => SendAsync(command, cancellationToken);

        [HttpGet]
        [POneAuthorize(Roles.Financial.Wallet.Read)]
        public Task<IActionResult> GetAllAsync([FromQuery] GetAllWallets query, CancellationToken cancellationToken) =>
            QueryAsync(query, cancellationToken);
    }
}

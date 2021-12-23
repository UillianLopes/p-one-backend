using POne.Core.Contracts;
using POne.Core.CQRS;
using POne.Financial.Domain.Commands.Inputs.Balances;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Business.CommandHandlers
{
    public class BalanceCommandHandler : ICommandHandler<CreateBalanceCommand>,
        ICommandHandler<UpdateBalanceCommand>,
        ICommandHandler<DeleteBalanceCommand>
    {
        private readonly IBalanceRepository _balanceRepsitory;
        private readonly IAuthenticatedUser _authenticatedUser;
        private readonly IBankRepository _bankRepsitory;

        public BalanceCommandHandler(IBalanceRepository balanceRepsitory, IAuthenticatedUser authenticatedUser, IBankRepository bankRepository)
        {
            _balanceRepsitory = balanceRepsitory;
            _authenticatedUser = authenticatedUser;
            _bankRepsitory = bankRepository;
        }

        public async Task<ICommandOuput> Handle(CreateBalanceCommand request, CancellationToken cancellationToken)
        {
            Bank bank = null;

            if (request.BankId is Guid bankId)
                bank = await _bankRepsitory.FindByIdAync(bankId, cancellationToken);

            var balance = new Balance(
                _authenticatedUser.Id,
                request.Value,
                request.Name,
                bank,
                request.Number,
                request.Agency,
                request.Type
            );

            await _balanceRepsitory.CreateAync(balance, cancellationToken);

            return CommandOutput.Created($"/category/{balance.Id}", new
            {
                balance.Id,
                request.Value,
                request.Name,
                request.Number,
                request.Agency,
                Bank = bank != null ? new { bank.Id, bank.Name, bank.Code } : null

            }, "@PONE.MESSAGES.BALANCE_CREATED");
        }

        public async Task<ICommandOuput> Handle(UpdateBalanceCommand request, CancellationToken cancellationToken)
        {
            if (await _balanceRepsitory.FindByIdAync(request.Id, cancellationToken) is not Balance balance)
                return CommandOutput.NotFound("@PONE.MESSAGES.BALANCE_NOT_FOUND");
            Bank bank = null;

            if (request.BankId is Guid bankId)
                bank = await _bankRepsitory.FindByIdAync(bankId, cancellationToken);

            balance.Update(
                request.Value,
                request.Name,
                bank,
                request.Number,
                request.Agency
            );

            return CommandOutput.Ok(new
            {
                balance.Id,
                balance.Value,
                balance.Name,
                balance.Number,
                balance.Agency,
                Bank = bank != null ? new { bank.Id, bank.Name, bank.Code } : null
            }, "@PONE.MESSAGES.BALANCE_UPDATED");
        }

        public async Task<ICommandOuput> Handle(DeleteBalanceCommand request, CancellationToken cancellationToken)
        {
            if (await _balanceRepsitory.FindByIdAync(request.Id, cancellationToken) is not Balance balance)
                return CommandOutput.NotFound("@PONE.MESSAGES.BALANCE_NOT_FOUND");

            _balanceRepsitory.Delete(balance);

            return CommandOutput.Ok("@PONE.MESSAGES.BALANCE_DELETED");
        }
    }
}

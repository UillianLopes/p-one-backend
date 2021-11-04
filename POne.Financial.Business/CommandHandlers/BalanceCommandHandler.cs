using POne.Core.Contracts;
using POne.Core.CQRS;
using POne.Financial.Domain.Commands.Inputs.Balances;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Domain;
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

        public BalanceCommandHandler(IBalanceRepository balanceRepsitory, IAuthenticatedUser authenticatedUser)
        {
            _balanceRepsitory = balanceRepsitory;
            _authenticatedUser = authenticatedUser;
        }

        public async Task<ICommandOuput> Handle(CreateBalanceCommand request, CancellationToken cancellationToken)
        {
            var balance = new Balance(_authenticatedUser.Id, request.Name, request.Value);

            await _balanceRepsitory.CreateAync(balance, cancellationToken);

            return CommandOutput.Created($"/category/{balance.Id}", new
            {
                balance.Id,
                balance.Name,
                balance.Value
            }, "@PONE.MESSAGES.BALANCE_CREATED");
        }

        public async Task<ICommandOuput> Handle(UpdateBalanceCommand request, CancellationToken cancellationToken)
        {
            if (await _balanceRepsitory.FindByIdAync(request.Id, cancellationToken) is not Balance balance)
                return CommandOutput.NotFound("@PONE.MESSAGES.BALANCE_NOT_FOUND");

            balance.Name = request.Name;
            balance.Value = request.Value;

            return CommandOutput.Ok(new
            {
                balance.Id,
                balance.Name,
                balance.Value
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

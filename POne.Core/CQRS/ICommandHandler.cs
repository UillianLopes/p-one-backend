using MediatR;

namespace POne.Core.CQRS
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, ICommandOuput> where TCommand : ICommand
    {
    }
}

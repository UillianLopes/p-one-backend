using MediatR;

namespace POne.Core.CQRS
{
    public interface ICommand : IRequest<ICommandOuput>
    {
    }
}

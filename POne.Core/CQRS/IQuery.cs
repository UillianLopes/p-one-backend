using MediatR;

namespace POne.Core.CQRS
{
    public interface IQuery : IRequest<IQueryOutput>
    {
    }
}

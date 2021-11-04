using MediatR;

namespace POne.Core.CQRS
{
    public interface IQueryHandler<T> : IRequestHandler<T, IQueryOutput> where T : IQuery
    {
    }
}

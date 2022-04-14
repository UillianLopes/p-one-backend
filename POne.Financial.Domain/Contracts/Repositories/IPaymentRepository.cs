using POne.Core.Contracts;
using POne.Financial.Domain.Entities;

namespace POne.Financial.Domain.Contracts
{
    public interface IPaymentRepository : IRepository<Payment>
    {
    }
}

using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Domain;
using POne.Financial.Infra.Connections;
using POne.Infra.Repositories;

namespace POne.Financial.Infra.Repositories
{
    public class PaymentRepository : Repository<POneFinancialDbContext, Payment>, IPaymentRepository
    {
        public PaymentRepository(POneFinancialDbContext dbContext) : base(dbContext)
        {
        }
    }
}

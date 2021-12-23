using POne.Core.CQRS;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Queries.Inputs.Banks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Business.QueryHandlers
{
    internal class BankQueryHandler : IQueryHandler<GetAllBanks>
    {
        private readonly IBankRepository _bankRespository;

        public BankQueryHandler(IBankRepository bankRespository)
        {
            _bankRespository = bankRespository;
        }

        public async Task<IQueryOutput> Handle(GetAllBanks request, CancellationToken cancellationToken)
        {
            var banks = await _bankRespository.GetAllAsync(request, cancellationToken);

            return QueryOutput.Ok(banks);
        }
    }
}

using POne.Core.CQRS;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Queries.Inputs.Entries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Business.QueryHandlers
{
    public class EntryQueryHandler : IQueryHandler<GetFiltredEntries>
    {
        private readonly IEntryRepository _entryRepository;

        public EntryQueryHandler(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public async Task<IQueryOutput> Handle(GetFiltredEntries request, CancellationToken cancellationToken)
        {
            var result = await _entryRepository.GetAllAsync(request, cancellationToken);

            return QueryOutput.Ok(result);
        }
    }
}

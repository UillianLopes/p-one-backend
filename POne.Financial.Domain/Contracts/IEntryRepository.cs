using POne.Core.Contracts;
using POne.Financial.Domain.Domain;
using POne.Financial.Domain.Queries.Inputs.Entries;
using POne.Financial.Domain.Queries.Outputs.Entries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Domain.Contracts
{
    public interface IEntryRepository : IRepository<Entry>
    {
        Task<List<EntryOutput>> GetAllAsync(GetFiltredEntries filter, CancellationToken cancellationToken);
    }
}

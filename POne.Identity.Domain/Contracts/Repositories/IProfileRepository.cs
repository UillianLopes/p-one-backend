using POne.Core.Contracts;
using POne.Identity.Domain.Entities;
using POne.Identity.Domain.Queries.Inputs.Profiles;
using POne.Identity.Domain.Queries.Outputs.Profiles;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Domain.Contracts.Repositories
{
    public interface IProfileRepository : IRepository<Profile>, IAsOptionsRepository<GetAllProfilesAsOptions>
    {
        Task<List<ProfileOutput>> GetAllAsync(GetAllProfiles query, CancellationToken cancellationToken);

    }
}

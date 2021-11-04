using POne.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Core.Contracts
{
    public interface IRepository<T> where T : Entity
    {
        Task CreateAync(T entity, CancellationToken cancellationToken);

        void Delete(T entity);

        void DeleteRange(T[] entity);

        Task<T> FindByIdAync(Guid id, CancellationToken cancellationToken);

        Task<List<T>> FindByIdsAync(Guid[] ids, CancellationToken cancellationToken);

        Task UpdateAsync(T entity, CancellationToken cancellationToken);
    }
}

using Microsoft.EntityFrameworkCore;
using POne.Core.Contracts;
using POne.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Infra.Repositories
{
    public abstract class Repository<TDbContext, TEntity> : IRepository<TEntity> where TEntity : Entity where TDbContext : DbContext
    {

        protected readonly TDbContext _dbContext;

        public Repository(TDbContext dbContext) => _dbContext = dbContext;

        public async Task CreateAync(TEntity entity, CancellationToken cancellationToken) => await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

        public void Delete(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);

        public void DeleteRange(TEntity[] entity) => _dbContext.Set<TEntity>().RemoveRange(entity);

        public Task<TEntity> FindByIdAync(Guid id, CancellationToken cancellationToken) => _dbContext
            .Set<TEntity>()
            .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

        public Task<List<TEntity>> FindByIdsAync(Guid[] ids, CancellationToken cancellationToken) => _dbContext
            .Set<TEntity>()
            .Where(entity => ids.Contains(entity.Id))
            .ToListAsync(cancellationToken);

        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken) => Task.Run(() => _dbContext.Set<TEntity>().Update(entity), cancellationToken);
    }
}

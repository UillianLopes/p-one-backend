using MediatR;
using Microsoft.EntityFrameworkCore;
using POne.Core.Contracts;
using POne.Core.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Infra.UnityOfWork
{
    public class Uow<TDbContext> : IUow where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;
        private readonly IMediator _mediator;

        public Uow(TDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);

                var eventEmmited = false;

                foreach (var entry in _dbContext.ChangeTracker.Entries())
                {
                    if (entry.Entity is not Entity entity)
                        continue;

                    foreach (var command in entity.Events)
                    {
                        if (!eventEmmited)
                            eventEmmited = true;

                        await _mediator.Publish(command, cancellationToken);
                    }


                    entity.ClearEvents();
                }

                if (eventEmmited)
                    await _dbContext.SaveChangesAsync(cancellationToken);

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}

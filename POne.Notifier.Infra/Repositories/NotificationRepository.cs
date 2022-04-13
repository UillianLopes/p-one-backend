using Microsoft.EntityFrameworkCore;
using POne.Core.Contracts;
using POne.Infra.Repositories;
using POne.Notifier.Domain.Contracts.Repositories;
using POne.Notifier.Domain.Entities;
using POne.Notifier.Domain.Queries.Inputs.Notifications;
using POne.Notifier.Domain.Queries.Outputs.Notifications;
using POne.Notifier.Infra.Connections;

namespace POne.Financial.Infra.Repositories
{
    public class NotificationRepository : Repository<POneNotifierDbContext, Notification>, INotificationRepository
    {
        private readonly IAuthenticatedUser _authenticatedUser;
        public NotificationRepository(IAuthenticatedUser authenticatedUser, POneNotifierDbContext dbContext) : base(dbContext)
        {
            _authenticatedUser = authenticatedUser;
        }

        public Task<List<NotificationOutput>> GetUnreadNotificationsAsync(GetUnreadNotifications request, CancellationToken cancellationToken)
        {
            return _dbContext.Notifications
                .Where(n => (n.UserId == _authenticatedUser.Id || n.UserId == null) && !n.NotificationStates
                    .Any(ns => ns.UserId == _authenticatedUser.Id && ns.IsRead))
                .Select(e => new NotificationOutput
                {
                    Id = e.Id,
                    Text = e.Text,
                    Title = e.Title,
                    Type = e.Type,
                    IsRead = false,
                    Creation = e.Creation
                })
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Entities;
using POne.Financial.Domain.Queries.Inputs.Notifications;
using POne.Financial.Domain.Queries.Outputs.Notifications;
using POne.Financial.Infra.Connections;
using POne.Infra.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Infra.Repositories
{
    public class NotificationRepository : Repository<POneFinancialDbContext, Notification>, INotificationRepository
    {
        public NotificationRepository(POneFinancialDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<NotificationOutput>> GetUnreadNotificationsAsync(GetUnreadNotifications request, CancellationToken cancellationToken)
        {
            return _dbContext.Notifications
                .Where(n => n.IsRead == false)
                .Select(e => new NotificationOutput { Id = e.Id, Text = e.Text, Title = e.Title, Type = e.Type })
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}

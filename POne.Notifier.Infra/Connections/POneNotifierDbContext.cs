using Microsoft.EntityFrameworkCore;
using POne.Notifier.Domain.Entities;
using POne.Notifier.Infra.Mappings;

namespace POne.Notifier.Infra.Connections
{
    public class POneNotifierDbContext : DbContext
    {
        public DbSet<Notification> Notifications { get; protected set; }

        public POneNotifierDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new NotificationMap());
            modelBuilder.ApplyConfiguration(new NotificationStateMap());
        }
    }
}

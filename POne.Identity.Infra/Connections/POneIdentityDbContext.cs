using Microsoft.EntityFrameworkCore;
using POne.Identity.Infra.Mappings;

namespace POne.Identity.Infra.Connections
{
    public class POneIdentityDbContext : DbContext
    {
        public POneIdentityDbContext(DbContextOptions<POneIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ProfileMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

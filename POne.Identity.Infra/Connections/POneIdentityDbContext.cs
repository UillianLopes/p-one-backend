using Microsoft.EntityFrameworkCore;
using POne.Identity.Domain.Entities;
using POne.Identity.Infra.Mappgins;
using POne.Identity.Infra.Mappings;

namespace POne.Identity.Infra.Connections
{
    public class POneIdentityDbContext : DbContext
    {
        public DbSet<Role> Roles { get; protected set; }
        public DbSet<Profile> Profiles { get; protected set; }
        public DbSet<User> Users { get; protected set; }

        public POneIdentityDbContext(DbContextOptions<POneIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ContactMap());
            modelBuilder.ApplyConfiguration(new ProfileMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

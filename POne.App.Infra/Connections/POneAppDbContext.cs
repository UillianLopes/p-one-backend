using Microsoft.EntityFrameworkCore;


namespace POne.App.Infra.Connections
{
    public class POneAppDbContext : DbContext
    {
        public POneAppDbContext(DbContextOptions<POneAppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

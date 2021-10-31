using Microsoft.EntityFrameworkCore;
using POne.Financial.Infra.Mappings;

namespace POne.Financial.Infra.Connections
{
    public class POneFinancialDbContext : DbContext
    {
        public POneFinancialDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BalanceMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new SubCategoryMap());
            modelBuilder.ApplyConfiguration(new EntryMap());
            modelBuilder.ApplyConfiguration(new PaymentMap());

        }
    }
}

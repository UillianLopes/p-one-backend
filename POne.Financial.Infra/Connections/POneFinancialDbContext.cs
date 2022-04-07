using Microsoft.EntityFrameworkCore;
using POne.Financial.Domain.Entities;
using POne.Financial.Infra.Mappings;

namespace POne.Financial.Infra.Connections
{
    public class POneFinancialDbContext : DbContext
    {
        public DbSet<Category> Categories { get; protected set; }
        public DbSet<SubCategory> SubCategories { get; protected set; }
        public DbSet<Wallet> Wallets { get; protected set; }
        public DbSet<Balance> Balances { get; protected set; }
        public DbSet<Entry> Entries { get; protected set; }
        public DbSet<Payment> Payments { get; protected set; }
        public DbSet<Bank> Banks { get; protected set; }
        public DbSet<Notification> Notifications { get; protected set; }

        public POneFinancialDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BankMap());
            modelBuilder.ApplyConfiguration(new WalletMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new SubCategoryMap());
            modelBuilder.ApplyConfiguration(new EntryMap());
            modelBuilder.ApplyConfiguration(new PaymentMap());
            modelBuilder.ApplyConfiguration(new BalanceMap());
            modelBuilder.ApplyConfiguration(new NotificationMap());

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Financial.Domain.Entities;
using POne.Infra.Mappings;

namespace POne.Financial.Infra.Mappings
{
    public class BalanceMap : EntityMap<Balance>
    {
        public override void Configure(EntityTypeBuilder<Balance> builder)
        {
            builder.ToTable("Balance", "fin");

            base.Configure(builder);

            builder.Property(b => b.Value)
                .IsRequired()
                .HasColumnType("Decimal(10,4)");

            builder.HasOne(b => b.Wallet)
                .WithMany(b => b.Balances)
                .IsRequired();
        }
    }
}

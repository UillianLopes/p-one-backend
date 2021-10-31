using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Financial.Domain.Domain;
using POne.Infra.Mappings;

namespace POne.Financial.Infra.Mappings
{
    public class BalanceMap : EntityMap<Balance>
    {
        public override void Configure(EntityTypeBuilder<Balance> builder)
        {
            base.Configure(builder);

            builder.ToTable("Balances", "fin");

            builder.Property(e => e.Value)
                .IsRequired();

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.UserId)
                .IsRequired();

            builder.HasIndex(e => e.UserId);
        }
    }
}

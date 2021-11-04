using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Financial.Domain.Domain;
using POne.Infra.Mappings;

namespace POne.Financial.Infra.Mappings
{
    public class PaymentMap : EntityMap<Payment>
    {
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payment", "fin");

            base.Configure(builder);

            builder.Property(e => e.Value)
                .IsRequired()
                .HasColumnType("Decimal(10,4)");

            builder.Property(e => e.Fees)
                .HasColumnType("Decimal(10,4)");

            builder.Property(e => e.Fine)
                .IsRequired()
                .HasColumnType("Decimal(10,4)");

            builder.HasOne(e => e.Entry)
                 .WithMany(e => e.Payments)
                 .IsRequired();

            builder.HasOne(e => e.Balance)
                 .WithMany(e => e.Payments);
        }
    }
}

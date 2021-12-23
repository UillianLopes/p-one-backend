using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Core.Enums;
using POne.Financial.Domain.Domain;
using POne.Infra.Mappings;
using System;

namespace POne.Financial.Infra.Mappings
{
    public class BalanceMap : EntityMap<Balance>
    {
        public override void Configure(EntityTypeBuilder<Balance> builder)
        {
            base.Configure(builder);

            builder.ToTable("Balances", "fin");

            builder.Property(e => e.Value)
                .IsRequired()
                .HasColumnType("Decimal(10,4)");

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.Agency)
                .HasMaxLength(20);

            builder.HasOne(e => e.Bank)
                .WithMany(e => e.Balances);

            builder.Property(e => e.Number)
                .HasMaxLength(50);

            builder.Property(e => e.Type)
                .HasConversion((e) => e.ToString(), (e) => Enum.IsDefined(typeof(BalanceType), e) ? (BalanceType)Enum.Parse(typeof(BalanceType), e) : default)
                .IsRequired();

            builder.Property(e => e.UserId)
                .IsRequired();

            builder.HasIndex(e => e.UserId);

            builder.HasMany(e => e.Payments)
                .WithOne(e => e.Balance);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Core.Enums;
using POne.Financial.Domain.Entities;
using POne.Infra.Mappings;
using System;

namespace POne.Financial.Infra.Mappings
{
    public class WalletMap : EntityMap<Wallet>
    {
        public override void Configure(EntityTypeBuilder<Wallet> builder)
        {
            base.Configure(builder);

            builder.ToTable("Wallets", "fin");

            builder.Property(e => e.Value)
                .IsRequired()
                .HasColumnType("Decimal(10,4)");

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.Agency)
                .HasMaxLength(20);

            builder.HasOne(e => e.Bank)
                .WithMany(e => e.Wallets);

            builder.Property(e => e.Number)
                .HasMaxLength(50);

            builder.Property(e => e.Currency)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.Color)
                .HasMaxLength(7);

            builder.Property(e => e.Type)
                .HasConversion((e) => e.ToString(), (e) => Enum.IsDefined(typeof(BalanceType), e) ? (BalanceType)Enum.Parse(typeof(BalanceType), e) : default)
                .IsRequired();

            builder.HasMany(e => e.Entries)
                .WithOne(e => e.Wallet);

            builder.Property(e => e.UserId);

            builder.HasIndex(e => e.UserId);

            builder.Property(e => e.AccountId);

            builder.HasIndex(e => e.AccountId);

            builder.HasMany(e => e.Payments)
                .WithOne(e => e.Wallet);
        }
    }
}

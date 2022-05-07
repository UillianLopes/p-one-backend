using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POne.Core.Enums;
using POne.Financial.Domain.Entities;
using POne.Infra.Mappings;
using System;
using System.Linq.Expressions;

namespace POne.Financial.Infra.Mappings
{
    public class EntryMap : EntityMap<Entry>
    {
        public override void Configure(EntityTypeBuilder<Entry> builder)
        {
            builder.ToTable("Entries", "fin");

            base.Configure(builder);

            builder.Property(e => e.UserId)
                .IsRequired();

            builder.HasIndex(e => e.UserId);

            builder.Property(e => e.RecurrenceId);

            builder.HasIndex(e => e.RecurrenceId);

            builder.Property(e => e.Index);

            builder.Property(e => e.Type)
                .HasConversion((e) => e.ToString(), (e) => Enum.IsDefined(typeof(EntryType), e) ? (EntryType)Enum.Parse(typeof(EntryType), e) : default)
                .IsRequired();

            builder.Property(e => e.Value)
                .IsRequired()
                .HasColumnType("Decimal(10,4)");

            builder.Property(e => e.DueDate)
                .IsRequired();

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(e => e.BarCode)
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .HasMaxLength(250);

            builder.HasOne(e => e.Category)
                .WithMany(e => e.Entries);

            builder.HasOne(e => e.SubCategory)
                .WithMany(e => e.Entries);

            builder.Property(e => e.Currency)
                .HasMaxLength(10);

            builder.HasMany(e => e.Payments)
                .WithOne(e => e.Entry)
                .IsRequired();

        }
    }
}

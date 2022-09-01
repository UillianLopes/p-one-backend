using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Core.Enums;
using POne.Financial.Domain.Entities;
using POne.Infra.Mappings;
using System;

namespace POne.Financial.Infra.Mappings
{
    public class EntryMap : EntityMap<Entry>
    {
        public override void Configure(EntityTypeBuilder<Entry> builder)
        {
            builder.ToTable("Entries", "fin");

            base.Configure(builder);

            builder.Property(e => e.UserId);

            builder.HasIndex(e => e.UserId);

            builder.Property(e => e.AccountId);

            builder.HasIndex(e => e.AccountId);

            builder.Property(e => e.InstallmentId);

            builder.HasIndex(e => e.InstallmentId);

            builder.Property(e => e.Index);

            builder.Property(e => e.Installments);

            builder.Property(e => e.Operation)
                .HasConversion((e) => e.ToString(), (e) => Enum.IsDefined(typeof(EntryOperation), e) ? (EntryOperation)Enum.Parse(typeof(EntryOperation), e) : default)
                .IsRequired();

            builder.Property(e => e.Recurrence)
              .HasConversion((e) => e != null ? e.ToString() : null, (e) => !string.IsNullOrEmpty(e) && Enum.IsDefined(typeof(EntryRecurrence), e) ? (EntryRecurrence)Enum.Parse(typeof(EntryRecurrence), e) : null);

            builder.Property(e => e.RecurrenceDayOfWeek)
              .HasConversion((e) => e != null ? e.ToString() : null, (e) => !string.IsNullOrEmpty(e) && Enum.IsDefined(typeof(DayOfWeek), e) ? (DayOfWeek)Enum.Parse(typeof(DayOfWeek), e) : null);

            builder.Property(e => e.RecurrenceDayOfMonth);

            builder.OwnsOne(e => e.RecurrenceEnd, (config) =>
            {
                config.Property(c => c.Year);
                config.Property(c => c.Month);
            });

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

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Core.Enums;
using POne.Financial.Domain.Domain;
using POne.Infra.Mappings;
using System;

namespace POne.Financial.Infra.Mappings
{
    public class CategoryMap : EntityMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "fin");

            base.Configure(builder);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(e => e.Description)
                .HasMaxLength(500);

            builder.Property(e => e.AccountId);

            builder.HasIndex(e => e.AccountId);

            builder.Property(e => e.UserId)
                .IsRequired();

            builder.HasIndex(e => e.UserId);

            builder.HasMany(e => e.Entries)
                .WithOne(e => e.Category);

            builder.Property(e => e.Type)
                .HasConversion((e) => e.ToString(), (e) => Enum.IsDefined(typeof(EntryType), e) ? (EntryType)Enum.Parse(typeof(EntryType), e) : default)
                .IsRequired();

            builder.HasMany(e => e.SubCategories)
                .WithOne(e => e.Category)
                .IsRequired();
        }
    }
}

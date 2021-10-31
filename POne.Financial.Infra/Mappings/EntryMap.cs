using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Financial.Domain.Domain;
using POne.Infra.Mappings;

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

            builder.Property(e => e.Type)
                .IsRequired();

            builder.Property(e => e.Recurrence)
                .IsRequired();

            builder.Property(e => e.Value)
                .IsRequired();

            builder.Property(e => e.Fees);

            builder.Property(e => e.Fine);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(e => e.Description)
                .HasMaxLength(250);

            builder.HasOne(e => e.Category)
                .WithMany(e => e.Entries);

            builder.HasOne(e => e.SubCategory)
                .WithMany(e => e.Entries);

            builder.HasMany(e => e.Payments)
                .WithOne(e => e.Entry)
                .IsRequired();

        }
    }
}

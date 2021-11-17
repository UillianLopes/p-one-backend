using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Financial.Domain.Domain;
using POne.Infra.Mappings;

namespace POne.Financial.Infra.Mappings
{
    class SubCategoryMap : EntityMap<SubCategory>
    {
        public override void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.ToTable("SubCategories", "fin");

            base.Configure(builder);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(e => e.Description)
                .HasMaxLength(250);

            builder.HasMany(e => e.Entries)
                .WithOne(e => e.SubCategory);

            builder.HasOne(e => e.Category)
                .WithMany(e => e.SubCategories)
                .IsRequired();
        }
    }
}

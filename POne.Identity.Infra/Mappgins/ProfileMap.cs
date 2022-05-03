using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Identity.Domain.Entities;
using POne.Infra.Mappings;

namespace POne.Identity.Infra.Mappings
{
    public class ProfileMap : EntityMap<Profile>
    {
        public override void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profiles", "auth");

            base.Configure(builder);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(254);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.IsActive)
                .IsRequired();

            builder.HasMany(p => p.Roles)
                .WithMany(p => p.Profiles);
        }
    }
}

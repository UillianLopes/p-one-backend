using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Domain.Entities;
using POne.Infra.Mappings;

namespace POne.Identity.Infra.Mappings
{
    public class RoleMap : EntityMap<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", "auth");

            base.Configure(builder);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(254);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Key)
                 .IsRequired()
                 .HasMaxLength(100);

            builder.Property(p => p.IsActive)
                .IsRequired();

            builder.HasMany(p => p.Profiles)
                .WithMany(p => p.Roles)
                .UsingEntity(builder => builder.ToTable("ProfilesRoles"));

            builder.HasMany(p => p.Users)
                .WithMany(p => p.Roles)
                .UsingEntity(builder => builder.ToTable("UsersRoles"));
        }
    }
}

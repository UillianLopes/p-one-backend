using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Core.Auth;
using POne.Identity.Domain.Entities;
using System.Linq;

namespace POne.Identity.Infra.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", "auth");

            builder.Property(p => p.Key)
                 .IsRequired()
                 .HasMaxLength(100)
                 .ValueGeneratedNever();

            builder.HasKey(p => p.Key);

            builder.HasMany(p => p.Profiles)
                .WithMany(p => p.Roles)
                .UsingEntity(builder => builder.ToTable("ProfileRoles"));

            builder.HasData(RolesUtils.GetAllRoleKeys()
                .Select(key => new { Key = key })
                .ToArray());

        }
    }
}

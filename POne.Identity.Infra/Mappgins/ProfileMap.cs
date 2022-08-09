using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Core.Auth;
using POne.Identity.Domain.Entities;
using POne.Infra.Mappings;
using System;
using System.Linq;

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

            builder.Property(p => p.IsDefault)
                .IsRequired();

            builder.HasOne(p => p.Account)
                .WithMany(p => p.Profiles)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(p => p.Roles)
                .WithMany(p => p.Profiles)
                .UsingEntity(b => b.HasData(RolesUtils
                    .GetAllRoleKeys()
                    .Select(key => new 
                    { 
                        RolesKey = key, 
                        ProfilesId = Guid.Parse("CE3B628F-3561-49E8-9560-6E24EF46DFE8")
                    }).ToArray()));

            builder.HasMany(p => p.Users)
                .WithOne(u => u.Profile)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new object[]
            {
                new
                {
                    Id = Guid.Parse("CE3B628F-3561-49E8-9560-6E24EF46DFE8"),
                    Creation = new DateTime(2022, 7, 12),
                    LastUpdate = new DateTime(2022, 7, 12),
                    IsDeleted = false,
                    Name = "POne Admin",
                    Description = "POne Admin profile",
                    IsDefault = true,
                    AccountId = Guid.Parse("CE4B628F-3561-49E8-9560-5E16EF46DFE9")
                }
            });

        }
    }
}

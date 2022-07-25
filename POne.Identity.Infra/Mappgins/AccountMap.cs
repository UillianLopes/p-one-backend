using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Identity.Domain.Entities;
using POne.Infra.Mappings;
using System;

namespace POne.Identity.Infra.Mappgins
{
    public class AccountMap : EntityMap<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);

            builder.Property(a => a.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(a => a.Description)
                .HasMaxLength(2000)
                .IsRequired();

            builder.HasMany(a => a.Profiles)
                .WithOne(p => p.Account)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Users)
                .WithOne(a => a.Account)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasData(new object[]
            {
                new
                {
                    Id = Guid.Parse("CE4B628F-3561-49E8-9560-5E16EF46DFE9"),
                    Creation = new DateTime(2022, 7, 12),
                    LastUpdate = new DateTime(2022, 7, 12),
                    IsDeleted = false,
                    Name = "POne",
                    Description = "POne Main Account"
                }
            });
        }
    }
}

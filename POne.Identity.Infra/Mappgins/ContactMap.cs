using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Identity.Domain.Entities;
using POne.Infra.Mappings;
using System;

namespace POne.Identity.Infra.Mappgins
{
    public class ContactMap : EntityMap<Contact>
    {
        public override void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts", "auth");

            base.Configure(builder);

            builder.Property(c => c.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.OwnsOne(c => c.Number, (c) =>
            {
                c.Property(n => n.Number)
                    .IsRequired()
                    .HasMaxLength(30);

                c.Property(n => n.CountryCode)
                    .IsRequired();

                c.HasData(new[] 
                {
                    new
                    {
                        Number = "999998888",
                        CountryCode = 55,
                        ContactId = Guid.Parse("6459B59A-EF4B-4D0C-BC63-4657E262701C")
                    }
                });
            });

            builder.HasOne(c => c.User)
                .WithMany(u => u.Contacts)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasData(new[]
            {
                new 
                { 
                    Id = Guid.Parse("6459B59A-EF4B-4D0C-BC63-4657E262701C"),
                    Creation = new DateTime(2022, 7, 12),
                    LastUpdate = new DateTime(2022, 7, 12),
                    IsDeleted = false,
                    Name = "Test contact",
                    UserId = Guid.Parse("3DE581C4-3F1A-4AC3-A395-24A697EDA880")
                }
            });

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Identity.Domain.Entities;
using POne.Infra.Mappings;
using System;
using System.Text;

namespace POne.Identity.Infra.Mappings
{
    public class UserMap : EntityMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "auth");

            base.Configure(builder);

            builder.Property(user => user.Name)
                .HasMaxLength(254)
                .IsRequired();

            builder.Property(user => user.Email)
                .HasMaxLength(254)
                .IsRequired();

            builder.Property(user => user.BirthDate)
                .IsRequired();

            builder.OwnsOne(user => user.Address, (address) =>
            {
                address.Property(a => a.City)
                    .HasMaxLength(150);

                address.Property(a => a.Country)
                    .HasMaxLength(150);

                address.Property(a => a.District)
                    .HasMaxLength(150);

                address.Property(a => a.Number)
                    .HasMaxLength(10);

                address.Property(a => a.State)
                    .HasMaxLength(150);

                address.Property(a => a.Street)
                    .HasMaxLength(254);

                address.Property(a => a.ZipCode)
                    .HasMaxLength(20);

                address.HasData(new object[]
                {
                    new
                    {
                        City = "Serra",
                        Country = "Brazil",
                        District = "Praia de capuba",
                        Number = "20",
                        State = "ES",
                        Street = "Rua Dolores Araujo de Oliveira",
                        ZipCode = "29173660",
                        UserId = Guid.Parse("3DE581C4-3F1A-4AC3-A395-24A697EDA880")
                    }
                });
            });

            builder.OwnsOne(user => user.Settings, (phone) =>
            {
                phone.Property(p => p.Value);

                phone.HasData(new object[]
                {
                    new
                    {
                        Value = Convert.ToBase64String(Encoding.UTF8.GetBytes(@"{ ""Language"": ""pt-BR"" }")),
                        UserId = Guid.Parse("3DE581C4-3F1A-4AC3-A395-24A697EDA880")
                    }
                });
            });

            builder.OwnsOne(user => user.Password, (password) =>
            {
                password.Property(p => p.Value)
                    .IsRequired();

                password.HasData(new object[]
                {
                    new
                    {
                        Value = "$2a$11$uxW.fi50RNvTC.GOq20dXu0mZzJ.wIAbjd2V5hEhm.YB62v1V1yIG",
                        UserId = Guid.Parse("3DE581C4-3F1A-4AC3-A395-24A697EDA880")
                    }
                });
            });

            builder.HasData(new object[] {
                new
                {
                    Id = Guid.Parse("3DE581C4-3F1A-4AC3-A395-24A697EDA880"),
                    AccountId = Guid.Parse("CE4B628F-3561-49E8-9560-5E16EF46DFE9"),
                    Creation = new DateTime(2022, 7, 12),
                    LastUpdate = new DateTime(2022, 7, 12),
                    IsDeleted = false,
                    Name = "Uillian de Souza Lopes",
                    Email = "uilliansl@outlook.com",
                    BirthDate = new DateTime(1996, 3, 27),
                    CurrentAccountId = Guid.Parse("CE4B628F-3561-49E8-9560-6E16EF46DFE6"),
                    ProfileId = Guid.Parse("CE3B628F-3561-49E8-9560-6E24EF46DFE8")
                }
            });

            builder.HasOne(p => p.Profile)
                .WithMany(u => u.Users)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.Contacts)
                .WithOne(c => c.User)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(u => u.Account)
                .WithMany(a => a.Users)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

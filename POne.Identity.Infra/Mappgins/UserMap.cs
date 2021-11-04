using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Core.Extensions;
using POne.Domain.Entities;
using POne.Infra.Mappings;
using System;

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

            builder.OwnsOne(user => user.MobilePhone, (phone) =>
            {
                phone.Property(p => p.CountryCode)
                    .IsRequired();

                phone.Property(p => p.Number)
                    .HasMaxLength(20)
                    .IsRequired();

                phone.HasData(new object[]
                {
                    new
                    {
                        CountryCode = 55,
                        Number = "27998321849",
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
                        Value = "Uil98690659-".Hash(),
                        UserId = Guid.Parse("3DE581C4-3F1A-4AC3-A395-24A697EDA880")
                    }
                });
            });

            builder.HasMany(user => user.Accounts)
                .WithMany(account => account.Users)
                .UsingEntity(builder => builder.ToTable("AccountsUsers"));

            builder.HasData(new object[] {
                new
                {
                    Id = Guid.Parse("3DE581C4-3F1A-4AC3-A395-24A697EDA880"),
                    AccountId = Guid.Parse("CE4B628F-3561-49E8-9560-6E16EF46DFE6"),
                    Creation = DateTime.Now,
                    LastUpdate = DateTime.Now,
                    IsDeleted = false,
                    Name = "Uillian de Souza Lopes",
                    Email = "uilliansl@outlook.com",
                    BirthDate = new DateTime(1996, 3, 27),
                    CurrentAccountId = Guid.Parse("CE4B628F-3561-49E8-9560-6E16EF46DFE6")
                }
            });

            builder.HasOne(e => e.CurrentAccount)
                .WithMany(e => e.CurrentUsers)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

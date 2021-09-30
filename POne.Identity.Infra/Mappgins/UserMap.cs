using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Domain.Entities;
using POne.Infra.Mappings;

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
            });

            builder.OwnsOne(user => user.MobilePhone, (phone) =>
            {
                phone.Property(p => p.CountryCode)
                    .IsRequired();

                phone.Property(p => p.Number)
                    .HasMaxLength(20)
                    .IsRequired();
            });

            builder.OwnsOne(user => user.Password, (password) =>
            {
                password.Property(p => p.Value)
                    .IsRequired();
            });

            builder.HasMany(user => user.Accounts)
                .WithMany(account => account.Users);
        }
    }
}

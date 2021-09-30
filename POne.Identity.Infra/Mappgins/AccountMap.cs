using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Domain.Entities;
using POne.Infra.Mappings;

namespace POne.Identity.Infra.Mappgins
{
    public class AccountMap : EntityMap<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts", "auth");

            base.Configure(builder);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(user => user.Email)
                .HasMaxLength(254)
                .IsRequired();

            builder.HasMany(p => p.Users)
                .WithMany(p => p.Accounts);

            builder.HasOne(p => p.ParentAccount)
                .WithMany(p => p.Accounts);
        }
    }
}

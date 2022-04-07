using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Core.Enums;
using POne.Financial.Domain.Entities;
using POne.Infra.Mappings;
using System;

namespace POne.Financial.Infra.Mappings
{
    public class NotificationMap : EntityMap<Notification>
    {
        public override void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications", "fin");

            base.Configure(builder);

            builder.Property(b => b.Title)
                .HasMaxLength(100)
                .IsRequired();


            builder.Property(b => b.Text)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(e => e.UserId)
                .IsRequired();

            builder.HasIndex(e => e.UserId);

            builder.Property(e => e.Type)
                .HasConversion((e) => e.ToString(), (e) => Enum.IsDefined(typeof(NotificationType), e) ? (NotificationType)Enum.Parse(typeof(NotificationType), e) : default)
                .IsRequired();

            builder.Property(e => e.IsRead)
                .IsRequired();

        }
    }
}

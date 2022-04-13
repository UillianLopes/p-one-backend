
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Core.Enums;
using POne.Infra.Mappings;
using POne.Notifier.Domain.Entities;

namespace POne.Notifier.Infra.Mappings
{
    public class NotificationMap : EntityMap<Notification>
    {
        public override void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications", "ntf");

            base.Configure(builder);

            builder.Property(n => n.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(n => n.Text)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(n => n.UserId);

            builder.HasIndex(n => n.UserId);

            builder.Property(n => n.Type)
                .HasConversion((n) => n.ToString(), (n) => Enum.IsDefined(typeof(NotificationType), n) ? (NotificationType)Enum.Parse(typeof(NotificationType), n) : default)
                .IsRequired();

            builder.Property(n => n.Application)
             .HasConversion((n) => n.ToString(), (n) => Enum.IsDefined(typeof(POneApplication), n) ? (POneApplication)Enum.Parse(typeof(POneApplication), n) : default)
             .IsRequired();

            builder.HasMany(n => n.NotificationStates)
                .WithOne(ns => ns.Notification)
                .IsRequired();

        }
    }
}

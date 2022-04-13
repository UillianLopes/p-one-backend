using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Infra.Mappings;
using POne.Notifier.Domain.Entities;

namespace POne.Notifier.Infra.Mappings
{
    public class NotificationStateMap : EntityMap<NotificationState>
    {
        public override void Configure(EntityTypeBuilder<NotificationState> builder)
        {
            builder.ToTable("NotificationStates", "ntf");

            base.Configure(builder);

            builder.Property(e => e.IsRead)
                .IsRequired();

            builder.Property(e => e.UserId)
                .IsRequired();

            builder.HasIndex(e => e.UserId);

            builder.HasOne(e => e.Notification)
                .WithMany(e => e.NotificationStates)
                .IsRequired();
        }
    }
}

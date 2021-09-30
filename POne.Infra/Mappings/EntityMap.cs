using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POne.Core.Entities;


namespace POne.Infra.Mappings
{
    public class EntityMap<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            builder.Property(e => e.Creation)
                .IsRequired();

            builder.Property(e => e.LastUpdate);

            builder.Property(e => e.IsDeleted)
                .IsRequired();
        }
    }
}

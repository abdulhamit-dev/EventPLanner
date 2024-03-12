using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class EventAttendeeConfigurations : IEntityTypeConfiguration<EventAttendee>
    {
        public void Configure(EntityTypeBuilder<EventAttendee> builder)
        {
            builder.ToTable("EventAttendees").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");

            builder.HasOne(b => b.Event);
            builder.HasOne(b => b.Attendee);
            

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}

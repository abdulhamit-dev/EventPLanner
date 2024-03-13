using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class EventConfigurations : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events").HasKey(b=>b.Id);
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");

            builder.HasIndex(indexExpression:b=>b.Name,name:"UK_Event_Name").IsUnique();

            builder.HasMany(b => b.EventAttendees);
            //builder.HasOne(b => b.Category);
            //builder.HasOne(b=>b.Speaker);
            //builder.HasOne(b=>b.Room);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}

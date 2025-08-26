using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Domain.Entities;

namespace VideoConference.Persistence.Configurations
{
    public class MeetingConfiguration : IEntityTypeConfiguration<Meeting>
    {
        public void Configure(EntityTypeBuilder<Meeting> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Title).IsRequired().HasMaxLength(200);

            builder.OwnsOne(m => m.Time, mt =>
            {
                mt.Property(t => t.Start).IsRequired();
                mt.Property(t => t.End).IsRequired();
            });

            builder.HasOne(m => m.Organizer)
                   .WithMany()
                   .HasForeignKey(m => m.OrganizerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

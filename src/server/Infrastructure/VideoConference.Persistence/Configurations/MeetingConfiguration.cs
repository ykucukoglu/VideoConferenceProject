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

            builder.Property(m => m.StartTime).IsRequired();
            builder.Property(m => m.EndTime).IsRequired();


            builder.HasOne(m => m.Organizer)
                   .WithMany()
                   .HasForeignKey(m => m.OrganizerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.Chats)
                   .WithOne(c => c.Meeting)
                   .HasForeignKey(c => c.MeetingId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.Property(x => x.AccessType).HasConversion<byte>().IsRequired();

        }
    }
}

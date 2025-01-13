using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Domain.Entities;

namespace VideoConference.Persistence.Configurations
{
    public class MeetingSettingConfiguration : IEntityTypeConfiguration<MeetingSetting>
    {
        public void Configure(EntityTypeBuilder<MeetingSetting> builder)
        {
            builder.HasKey(ms => ms.Id);
            builder.Property(ms => ms.AllowRecording).IsRequired();
            builder.Property(ms => ms.MaxParticipants).IsRequired();
            builder.HasOne(ms => ms.Meeting)
                   .WithOne(m => m.Settings)
                   .HasForeignKey<MeetingSetting>(ms => ms.MeetingId);
        }
    }
}

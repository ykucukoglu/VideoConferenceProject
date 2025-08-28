using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoConference.Domain.Entities;
using VideoConference.Domain.Enums;

namespace VideoConference.Persistence.Configurations
{
    public class MeetingParticipantConfiguration : IEntityTypeConfiguration<MeetingParticipant>
    {
        public void Configure(EntityTypeBuilder<MeetingParticipant> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(mp => mp.Role)
                   .WithMany()
                   .HasForeignKey(mp => mp.RoleId)
                   .IsRequired();


            builder.Property(p => p.IsAccepted)
                   .HasDefaultValue(false);

            // Meeting ile ilişki
            builder.HasOne(mp => mp.Meeting)
                   .WithMany(m => m.Participants)
                   .HasForeignKey(mp => mp.MeetingId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(mp => mp.User)
                   .WithMany(u => u.MeetingParticipations)
                   .HasForeignKey(mp => mp.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

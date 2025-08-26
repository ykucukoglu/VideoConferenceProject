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

            // Role property için converter ekleniyor
            builder.Property(p => p.Role)
                   .HasConversion(
                       r => r.Id,                 // DB'de int olarak saklanacak
                       id => MeetingRole.FromId(id) // DB'den okurken MeetingRole instance döndürülecek
                   )
                   .IsRequired()
                   .HasColumnName("RoleId");

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
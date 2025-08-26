using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoConference.Domain.Entities;
using VideoConference.Domain.Enums;

namespace VideoConference.Persistence.Configurations
{
    public class TeamMemberConfiguration : IEntityTypeConfiguration<TeamMember>
    {
        public void Configure(EntityTypeBuilder<TeamMember> builder)
        {

            builder.Property(tm => tm.Role)
                   .HasConversion(
                       r => r.Id,
                       id => TeamRole.FromId(id)
                   )
                   .IsRequired()
                   .HasColumnName("RoleId");

            builder.HasOne(tm => tm.Team)
                   .WithMany(t => t.Members)
                   .HasForeignKey(tm => tm.TeamId);

            builder.HasOne(tm => tm.User)
                   .WithMany(u => u.TeamMemberships)
                   .HasForeignKey(tm => tm.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }


}

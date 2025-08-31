using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoConference.Domain.Entities;

namespace VideoConference.Persistence.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(t => t.Members)
                .WithOne(tm => tm.Team)
                .HasForeignKey(m => m.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.Channels)
                .WithOne(tm => tm.Team)
                .HasForeignKey(c => c.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Organization)
                .WithMany(o => o.Teams)
                .HasForeignKey(t => t.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

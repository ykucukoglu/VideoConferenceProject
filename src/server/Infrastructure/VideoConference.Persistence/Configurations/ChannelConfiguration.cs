using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoConference.Domain.Entities;

namespace VideoConference.Persistence.Configurations
{
    public partial class ChannelConfiguration : IEntityTypeConfiguration<Channel>
    {
        public void Configure(EntityTypeBuilder<Channel> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.HasMany(c => c.Messages)
                   .WithOne(m => m.Channel)
                   .HasForeignKey(m => m.ChannelId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Team)
                   .WithMany(t => t.Channels)
                   .HasForeignKey(c => c.TeamId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(c => c.Community)
                   .WithMany(t => t.Channels)
                   .HasForeignKey(c => c.CommunityId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(c => c.Meetings)
                   .WithOne(m => m.Channel)
                   .HasForeignKey(m => m.ChannelId)
                   .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
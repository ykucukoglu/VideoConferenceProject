using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VideoConference.Domain.Entities;

namespace VideoConference.Persistence.Configurations
{
    public class ChannelConfiguration : IEntityTypeConfiguration<Channel>
    {
        public void Configure(EntityTypeBuilder<Channel> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.HasMany(c => c.Messages)
                   .WithOne(m => m.Channel)
                   .HasForeignKey(m => m.ChannelId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Team)       // Channel -> Team navigation property
                   .WithMany(t => t.Channels) // Team -> Channels collection
                   .HasForeignKey(c => c.TeamId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(c => c.Meetings)
                   .WithOne(m => m.Channel)
                   .HasForeignKey(m => m.ChannelId)
                   .OnDelete(DeleteBehavior.SetNull);

        }
    }
}

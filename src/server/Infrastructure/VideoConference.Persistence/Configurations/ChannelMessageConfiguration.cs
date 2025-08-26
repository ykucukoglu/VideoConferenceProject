using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoConference.Domain.Entities;

namespace VideoConference.Persistence.Configurations
{
    public class ChannelMessageConfiguration : IEntityTypeConfiguration<ChannelMessage>
    {
        public void Configure(EntityTypeBuilder<ChannelMessage> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Content)
                .IsRequired()
                .HasMaxLength(2000);

            builder.HasOne(cm => cm.Sender)
                   .WithMany()
                   .HasForeignKey(cm => cm.SenderId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }


}

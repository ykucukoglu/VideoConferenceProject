using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoConference.Domain.Entities;

namespace VideoConference.Persistence.Configurations
{
    public class ChatMemberConfiguration : IEntityTypeConfiguration<ChatMember>
    {
        public void Configure(EntityTypeBuilder<ChatMember> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasIndex(m => new { m.ChatId, m.UserId })
                   .IsUnique();

            builder.HasOne(cm => cm.Chat)
                   .WithMany(c => c.Members)
                   .HasForeignKey(cm => cm.ChatId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(cm => cm.User)
                   .WithMany(u => u.ChatMemberships)
                   .HasForeignKey(cm => cm.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }

}

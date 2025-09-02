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
    public class CommunityConfig : IEntityTypeConfiguration<Community>
    {
        public void Configure(EntityTypeBuilder<Community> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(t => t.Members)
              .WithOne(tm => tm.Community)
              .HasForeignKey(m => m.CommunityId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.Channels)
                .WithOne(tm => tm.Community)
                .HasForeignKey(c => c.CommunityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Owner)
                .WithMany(u => u.OwnedCommunities)
                .HasForeignKey(c => c.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

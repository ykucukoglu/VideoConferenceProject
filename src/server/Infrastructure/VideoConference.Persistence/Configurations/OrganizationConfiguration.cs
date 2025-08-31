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
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasOne(o => o.Owner)
                   .WithMany()
                   .HasForeignKey(o => o.OwnerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(o => o.Teams)
                   .WithOne(t => t.Organization)
                   .HasForeignKey(t => t.OrganizationId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoConference.Domain.Entities;

namespace VideoConference.Persistence.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("UserRoles");

            builder.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(u => u.UserId).IsRequired();
            builder.HasOne(ur => ur.Role).WithMany(u => u.UserRoles).HasForeignKey(u => u.RoleId).IsRequired();

        }
    }
}


using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoConference.Domain.Entities;

namespace VideoConference.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Primary key
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("Users");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(256);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<UserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<UserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<UserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            // builder.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            builder.HasMany(ur => ur.UserRoles).WithOne(ur => ur.User).HasForeignKey(ur => ur.UserId).IsRequired();

            builder.HasMany(u => u.ChatMemberships)
                   .WithOne(cm => cm.User)
                   .HasForeignKey(cm => cm.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.ChatMessages)
                   .WithOne(cm => cm.Sender)
                   .HasForeignKey(cm => cm.SenderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.ChannelMessages)
                   .WithOne(cm => cm.Sender)
                   .HasForeignKey(cm => cm.SenderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.MeetingParticipations)
                   .WithOne(mp => mp.User)
                   .HasForeignKey(mp => mp.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.TeamMemberships)
                   .WithOne(tm => tm.User)
                   .HasForeignKey(tm => tm.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.OrganizedMeetings)
                   .WithOne(m => m.Organizer)
                   .HasForeignKey(m => m.OrganizerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.CommunityMemberships)
                   .WithOne(cm => cm.User)
                   .HasForeignKey(cm => cm.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }


    }
}

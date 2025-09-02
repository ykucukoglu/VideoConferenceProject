using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Domain.Constants;
using VideoConference.Domain.Entities;
using VideoConference.Domain.Enums;
using VideoConference.Persistence.Contexts;

namespace VideoConference.Persistence.Seeds
{
    public static class AppDbContextSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Role>().HasData(
                           new Role
                           {
                               Id = Guid.Parse("7E4A8662-CD8A-45BA-855A-DF6797FEE712"),
                               Name = RoleConstants.GlobalAdmin,
                               NormalizedName = RoleConstants.GlobalAdmin.ToUpper(CultureInfo.InvariantCulture),
                               Scope = RoleScope.System
                           },
                           new Role
                           {
                               Id = Guid.Parse("D816C415-EB32-451D-80A2-6FC991BAC56F"),
                               Name = RoleConstants.OrganizationOwner,
                               NormalizedName = RoleConstants.OrganizationOwner.ToUpper(CultureInfo.InvariantCulture),
                               Scope = RoleScope.Oganization
                           },
                           new Role
                           {
                               Id = Guid.Parse("C311518B-0BF8-418A-B8D4-E6945F274E10"),
                               Name = RoleConstants.TeamOwner,
                               NormalizedName = RoleConstants.TeamOwner.ToUpper(CultureInfo.InvariantCulture),
                               Scope = RoleScope.Team
                           },
                           new Role
                           {
                               Id = Guid.Parse("F9231D9C-6C5A-47D8-AB21-578BD4441C70"),
                               Name = RoleConstants.TeamMember,
                               NormalizedName = RoleConstants.TeamMember.ToUpper(CultureInfo.InvariantCulture),
                               Scope = RoleScope.Team
                           },
                           new Role
                           {
                               Id = Guid.Parse("2EA79ED3-A8BC-40C1-A82A-BF943FD0C24E"),
                               Name = RoleConstants.ChannelOwner,
                               NormalizedName = RoleConstants.ChannelOwner.ToUpper(CultureInfo.InvariantCulture),
                               Scope = RoleScope.Channel
                           },
                           new Role
                           {
                               Id = Guid.Parse("E03D445D-CC7F-433E-A159-10204A913088"),
                               Name = RoleConstants.ChannelMember,
                               NormalizedName = RoleConstants.ChannelMember.ToUpper(CultureInfo.InvariantCulture),
                               Scope = RoleScope.Channel
                           },
                           new Role
                           {
                               Id = Guid.Parse("FDF961DA-8E18-486B-B6BB-78E28D088CB2"),
                               Name = RoleConstants.ChatOwner,
                               NormalizedName = RoleConstants.ChatOwner.ToUpper(CultureInfo.InvariantCulture),
                               Scope = RoleScope.Chat
                           },
                           new Role
                           {
                               Id = Guid.Parse("005A686A-1F38-437B-BFB3-A1A12C9AC2E7"),
                               Name = RoleConstants.ChatMember,
                               NormalizedName = RoleConstants.ChatMember.ToUpper(CultureInfo.InvariantCulture),
                               Scope = RoleScope.Chat
                           },
                           new Role
                           {
                               Id = Guid.Parse("420F357A-15E9-43C8-81F2-4176542918D0"),
                               Name = RoleConstants.MeetingOrganizer,
                               NormalizedName = RoleConstants.MeetingOrganizer.ToUpper(CultureInfo.InvariantCulture),
                               Scope = RoleScope.Meeting
                           },
                           new Role
                           {
                               Id = Guid.Parse("1A6DFFB5-96BC-4FE1-BDD6-2BAECEF4F4F6"),
                               Name = RoleConstants.MeetingCoHost,
                               NormalizedName = RoleConstants.MeetingCoHost.ToUpper(CultureInfo.InvariantCulture),
                               Scope = RoleScope.Meeting
                           },
                           new Role
                           {
                               Id = Guid.Parse("01945CC4-BF9B-4A4F-B89E-3B6314C4F795"),
                               Name = RoleConstants.MeetingParticipant,
                               NormalizedName = RoleConstants.MeetingParticipant.ToUpper(CultureInfo.InvariantCulture),
                               Scope = RoleScope.Meeting
                           },
                           new Role
                           {
                               Id = Guid.Parse("32A1E439-77C1-4043-A3B4-8DF3AF416F27"),
                               Name = RoleConstants.Guest,
                               NormalizedName = RoleConstants.Guest.ToUpper(CultureInfo.InvariantCulture),
                               Scope = RoleScope.System
                           },
                           new Role
                           {
                               Id = Guid.Parse("ABCE1401-FFBA-419E-B517-18AF8CFF15D1"),
                               Name = RoleConstants.CommunityOwner,
                               NormalizedName = RoleConstants.CommunityOwner.ToUpper(CultureInfo.InvariantCulture),
                               Scope = RoleScope.Community
                           },
                           new Role
                           {
                               Id = Guid.Parse("A46A7B39-95A4-4E43-9727-06B5568C6D83"),
                               Name = RoleConstants.CommunityMember,
                               NormalizedName = RoleConstants.CommunityMember.ToUpper(CultureInfo.InvariantCulture),
                               Scope = RoleScope.Community
                           }
            );

            //modelBuilder.Entity<User>().HasData(
            //    new User
            //    {
            //        Id = Guid.Parse("621A6B12-5AE7-410C-8762-5A75C548078C"),
            //        UserName = "yasemenkucukoglu@gmail.com",
            //        NormalizedUserName = "YASEMENKUCUKOGLU@GMAIL.COM",
            //        Email = "yasemenkucukoglu@gmail.com",
            //        NormalizedEmail = "YASEMENKUCUKOGLU@GMAIL.COM",
            //        PhoneNumber = "+905420000000",
            //        PhoneNumberConfirmed = true,
            //        EmailConfirmed = true,
            //        TwoFactorEnabled = false,
            //        SecurityStamp = "96269cb0-1087-4e42-9cc2-24ba32839db4",
            //        PasswordHash = "AQAAAAIAAYagAAAAEJKqT2W5OA0Bdr2wbQBCDh04Q5ofOPWd6PKTm/fK4uAiJ+l/Rf0H7+Bx8FviiCVy0w=="
            //    });


            //modelBuilder.Entity<UserRole>().HasData(new UserRole
            //{
            //    UserId = Guid.Parse("621A6B12-5AE7-410C-8762-5A75C548078C"),
            //    RoleId = Guid.Parse("7E4A8662-CD8A-45BA-855A-DF6797FEE712")
            //});
        }


        private static string CreatePasswordHash(User user, string password)
        {
            var passwordHasher = new PasswordHasher<User>();
            return passwordHasher.HashPassword(user, password);
        }
    }

}

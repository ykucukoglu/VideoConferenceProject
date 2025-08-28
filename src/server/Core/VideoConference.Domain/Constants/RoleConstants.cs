using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Domain.Constants
{
    public static class RoleConstants
    {
        public const string GlobalAdmin = "GlobalAdmin";
        public const string OrganizationOwner = "OrganizationOwner";
        public const string TeamOwner = "TeamOwner";
        public const string TeamMember = "TeamMember";
        public const string ChannelOwner = "ChannelOwner";
        public const string ChannelMember = "ChannelMember";
        public const string ChatOwner = "ChatOwner";
        public const string ChatMember = "ChatMember";
        public const string MeetingOrganizer = "MeetingOrganizer";
        public const string MeetingCoHost = "MeetingCoHost";
        public const string MeetingParticipant = "MeetingParticipant";
        public const string Guest = "Guest";
    }
}

using Microsoft.AspNetCore.Identity;

namespace VideoConference.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public ICollection<ChatMember>? ChatMemberships { get;  set; }
        public ICollection<ChatMessage>? ChatMessages { get;  set; }
        public ICollection<ChannelMessage>? ChannelMessages { get;  set; }
        public ICollection<MeetingParticipant>? MeetingParticipations { get;  set; }
        public ICollection<TeamMember>? TeamMemberships { get;  set; }
        public ICollection<Meeting>? OrganizedMeetings { get;  set; }
        public ICollection<UserRole>? UserRoles { get;  set; }

    }
}
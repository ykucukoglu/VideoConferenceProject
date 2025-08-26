using Microsoft.AspNetCore.Identity;
using VideoConference.Domain.Primitives;

namespace VideoConference.Domain.Entities
{
    public class User : IdentityUser<Guid>, IBaseEntity
    {
        public string FullName { get; private set; }
        public string? RefreshToken { get; private set; }
        public DateTime? RefreshTokenExpiryTime { get; private set; }

        // Navigation properties
        public ICollection<ChatMember> ChatMemberships { get; private set; } = new List<ChatMember>();
        public ICollection<ChatMessage> ChatMessages { get; private set; } = new List<ChatMessage>();
        public ICollection<ChannelMessage> ChannelMessages { get; private set; } = new List<ChannelMessage>();
        public ICollection<MeetingParticipant> MeetingParticipations { get; private set; } = new List<MeetingParticipant>();
        public ICollection<TeamMember> TeamMemberships { get; private set; } = new List<TeamMember>();
        public ICollection<Meeting> OrganizedMeetings { get; private set; } = new List<Meeting>();

        protected User() { }

        public User(string fullName, string email)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Email = email;
            UserName = email;
        }

        public void SetRefreshToken(string? token, DateTime? expiry)
        {
            RefreshToken = token;
            RefreshTokenExpiryTime = expiry;
        }


        public void RevokeRefreshToken()
        {
            RefreshToken = null;
            RefreshTokenExpiryTime = null;
        }
    }
}

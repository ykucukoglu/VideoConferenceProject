using VideoConference.Domain.Common;
using VideoConference.Domain.Enums;

namespace VideoConference.Domain.Entities
{
    public class Meeting : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public MeetingAccessType AccessType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid OrganizerId { get; set; }
        public User? Organizer { get; set; }
        public ICollection<MeetingParticipant> Participants { get; set; }
        public ICollection<Chat>? Chats { get; set; }
    }
}

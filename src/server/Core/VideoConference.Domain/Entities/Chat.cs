using VideoConference.Domain.Common;

namespace VideoConference.Domain.Entities
{
    public class Chat : BaseEntity
    {
        public string Name { get;  set; }
        public Guid? MeetingId { get; set; }
        public Meeting? Meeting { get; set; }
        public ICollection<ChatMember>? Members { get;  set; } 
        public ICollection<ChatMessage>? Messages { get;  set; }

    }
}

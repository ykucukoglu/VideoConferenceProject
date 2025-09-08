using VideoConference.Domain.Common;

namespace VideoConference.Domain.Entities
{
    public class ChatMessage : BaseEntity
    {
        public Guid ChatId { get;  set; }
        public Chat? Chat { get;  set; }

        public Guid SenderId { get;  set; }
        public User? Sender { get;  set; }
        public string Content { get;  set; }
        public DateTime SentAt { get; set; }
    }
}

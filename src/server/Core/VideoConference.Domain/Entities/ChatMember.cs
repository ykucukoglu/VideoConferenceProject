using VideoConference.Domain.Common;

namespace VideoConference.Domain.Entities
{
    public class ChatMember : BaseEntity
    {
        public Guid ChatId { get;  set; }
        public Chat Chat { get;  set; }

        public Guid UserId { get;  set; }
        public User User { get;  set; }
    }
}

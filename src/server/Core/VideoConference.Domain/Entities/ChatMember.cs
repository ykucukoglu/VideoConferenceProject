using VideoConference.Domain.Primitives;

namespace VideoConference.Domain.Entities
{
    public class ChatMember : BaseEntity
    {
        public Guid ChatId { get; private set; }
        public Chat Chat { get; private set; }

        public Guid UserId { get; private set; }
        public User User { get; private set; }
        protected ChatMember() { }

        public ChatMember(Guid chatId, Guid userId)
        {
            ChatId = chatId;
            UserId = userId;
        }
    }
}


using VideoConference.Domain.Primitives;

namespace VideoConference.Domain.Entities
{
    public class ChatMessage : BaseEntity
    {
        public Guid ChatId { get; private set; }
        public Chat Chat { get; private set; }

        public Guid SenderId { get; private set; }
        public User Sender { get; private set; }
        public string Content { get; private set; }

        protected ChatMessage() { }

        public ChatMessage(Guid chatId, Guid senderId, string content)
        {
            ChatId = chatId;
            SenderId = senderId;
            Content = content;
        }
    }
}


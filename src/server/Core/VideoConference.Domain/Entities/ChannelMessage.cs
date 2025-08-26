using VideoConference.Domain.Primitives;

namespace VideoConference.Domain.Entities
{
    public class ChannelMessage : BaseEntity
    {
        public Guid ChannelId { get; private set; }
        public Channel Channel { get; private set; }

        public Guid SenderId { get; private set; }
        public User Sender { get; private set; }

        public string Content { get; private set; }

        protected ChannelMessage() { }

        public ChannelMessage(Guid channelId, Guid senderId, string content)
        {
            ChannelId = channelId;
            SenderId = senderId;
            Content = content;
        }
    }
}
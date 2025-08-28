using VideoConference.Domain.Common;

namespace VideoConference.Domain.Entities
{
    public class ChannelMessage : BaseEntity
    {
        public Guid ChannelId { get; set; }
        public Channel Channel { get; set; }

        public Guid SenderId { get; set; }
        public User Sender { get; set; }

        public string Content { get; set; }
    }
}

using VideoConference.Domain.Common;

namespace VideoConference.Domain.Entities
{
    public class Channel : BaseEntity
    {
        public string Name { get; set; }
        public Guid TeamId { get; set; }
        public Team Team { get; set; }

        public ICollection<ChannelMessage>? Messages { get; set; }
        public ICollection<Meeting>? Meetings { get; set; }

    }
}

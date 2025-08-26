using VideoConference.Domain.Primitives;

namespace VideoConference.Domain.Entities
{
    public class Channel : BaseEntity
    {
        public string Name { get; private set; }
        public Guid TeamId { get; private set; }
        public Team Team { get; private set; }

        public ICollection<ChannelMessage> Messages { get; private set; } = new List<ChannelMessage>();
        public ICollection<Meeting> Meetings { get; private set; } = new List<Meeting>();

        protected Channel() { }

        public Channel(string name, Guid teamId)
        {
            Name = name;
            TeamId = teamId;
        }

        public static Channel Create(string name, Guid teamId) => new Channel(name, teamId);

        public void AddMessage(Guid senderId, string content)
        {
            Messages.Add(new ChannelMessage(Id, senderId, content));
        }
    }
}
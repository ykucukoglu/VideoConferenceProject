using VideoConference.Domain.Common;

namespace VideoConference.Domain.Entities
{
    public class Channel : BaseEntity
    {
        public string Name { get; set; }
        // Kurumsal senaryo için
        public Guid? TeamId { get; set; }
        public Team? Team { get; set; }

        // Bireysel senaryo için
        public Guid? CommunityId { get; set; }
        public Community? Community { get; set; }

        public ICollection<ChannelMessage>? Messages { get; set; }

    }
}

using VideoConference.Domain.Common;

namespace VideoConference.Domain.Entities
{
    public class Team : BaseEntity
    {
        public string Name { get;  set; }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public ICollection<TeamMember>? Members { get;  set; }
        public ICollection<Channel>? Channels { get;  set; }

    }
}

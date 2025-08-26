using VideoConference.Domain.Enums;
using VideoConference.Domain.Primitives;

namespace VideoConference.Domain.Entities
{
    public class TeamMember : BaseEntity
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public Guid TeamId { get; private set; }
        public Team Team { get; private set; }

        public TeamRole Role { get; private set; }

        protected TeamMember() { }

        public TeamMember(Guid userId, Guid teamId, TeamRole role)
        {
            UserId = userId;
            TeamId = teamId;
            Role = role;
        }
    }
}

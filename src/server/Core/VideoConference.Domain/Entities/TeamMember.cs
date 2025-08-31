using VideoConference.Domain.Common;
using VideoConference.Domain.Enums;

namespace VideoConference.Domain.Entities
{
    public class TeamMember : BaseEntity
    {
        public Guid UserId { get;  set; }
        public User? User { get;  set; }
        public Guid TeamId { get;  set; }
        public Team? Team { get;  set; }
        public Guid RoleId { get; set; }
        public Role? Role { get;  set; }
    }
}

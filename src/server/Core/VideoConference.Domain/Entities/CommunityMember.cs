using VideoConference.Domain.Common;

namespace VideoConference.Domain.Entities
{
    public class CommunityMember : BaseEntity
    {
        public Guid CommunityId { get; set; }
        public Community Community { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid RoleId { get; set; }
        public Role? Role { get; set; }
    }
}

using VideoConference.Domain.Common;
using VideoConference.Domain.Enums;

namespace VideoConference.Domain.Entities
{
    public class MeetingParticipant : BaseEntity
    {
        public Guid MeetingId { get;  set; }
        public Meeting Meeting { get;  set; }
        public Guid UserId { get;  set; }
        public User User { get;  set; }
        public Guid RoleId { get; set; }
        public Role Role { get;  set; }
        public bool IsAccepted { get;  set; }
    }
}

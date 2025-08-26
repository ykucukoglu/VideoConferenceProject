using VideoConference.Domain.Enums;
using VideoConference.Domain.Primitives;

namespace VideoConference.Domain.Entities
{
    public class MeetingParticipant : BaseEntity
    {
        public Guid MeetingId { get; private set; }   // FK property
        public Meeting Meeting { get; private set; }  // Navigation property
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public MeetingRole Role { get; private set; }
        public bool IsAccepted { get; private set; }

        protected MeetingParticipant() { }

        public MeetingParticipant(Guid meetingId, Guid userId, MeetingRole role)
        {
            MeetingId = meetingId;
            UserId = userId;
            Role = role;
        }

        public void Accept() => IsAccepted = true;
        public void Decline() => IsAccepted = false;
    }
}

using VideoConference.Domain.Common;

namespace VideoConference.Domain.Entities
{
    public class Meeting : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid OrganizerId { get; set; }
        public User? Organizer { get; set; }
        public Guid SettingId { get; set; }
        public Guid? ChannelId { get; set; }
        public Channel? Channel { get; set; }
        public ICollection<MeetingParticipant> Participants { get; set; }
    }
}

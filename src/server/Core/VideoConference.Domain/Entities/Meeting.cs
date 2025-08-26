using VideoConference.Domain.Enums;
using VideoConference.Domain.Primitives;
using VideoConference.Domain.ValueObjects;

namespace VideoConference.Domain.Entities
{
    public class Meeting : BaseEntity
    {
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public MeetingTime Time { get; private set; }
        public Guid OrganizerId { get; private set; }
        public User Organizer { get; private set; }
        public Guid? ChannelId { get; private set; }
        public Channel? Channel { get; private set; }

        public ICollection<MeetingParticipant> Participants { get; private set; } = new List<MeetingParticipant>();

        protected Meeting() { }

        private Meeting(string title, MeetingTime time, Guid organizerId, string? description = null, Guid? channelId = null)
        {
            Title = title;
            Time = time;
            OrganizerId = organizerId;
            Description = description;
            ChannelId = channelId;
        }

        public static Meeting Schedule(string title, DateTime start, DateTime end, Guid organizerId, string? description = null, Guid? channelId = null)
        {
            return new Meeting(title, MeetingTime.Create(start, end), organizerId, description, channelId);
        }

        public void InviteParticipant(Guid userId, MeetingRole role)
        {
            Participants.Add(new MeetingParticipant(Id, userId, role));
        }
    }
}

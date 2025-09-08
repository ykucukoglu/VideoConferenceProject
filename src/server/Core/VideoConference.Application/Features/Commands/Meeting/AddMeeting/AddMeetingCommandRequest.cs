using MediatR;

namespace VideoConference.Application.Features.Commands.Meeting.AddMeeting
{
    public class AddMeetingCommandRequest : IRequest<AddMeetingCommandResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

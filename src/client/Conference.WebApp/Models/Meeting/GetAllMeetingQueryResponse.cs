using VideoConference.Application.DTOs.Meetings;

namespace Conference.WebApp.Models.Meeting
{
    public class GetAllMeetingQueryResponse
    {
        public List<MeetingDTO> Meetings { get; set; }
    }
}

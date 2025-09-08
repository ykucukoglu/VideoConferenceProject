using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.DTOs.MeetingParticipants;
using VideoConference.Application.DTOs.Meetings;

namespace VideoConference.Application.Features.Queries.Meeting.GetAllMeeting
{
    public class GetAllMeetingParticipantQueryResponse
    {
        public List<MeetingParticipantDTO> MeetingParticipants { get; set; }
    }
}

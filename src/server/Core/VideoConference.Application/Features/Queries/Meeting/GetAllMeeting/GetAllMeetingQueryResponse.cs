using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.DTOs.Meetings;

namespace VideoConference.Application.Features.Queries.Meeting.GetAllMeeting
{
    public class GetAllMeetingQueryResponse
    {
        public List<MeetingDTO> Meetings { get; set; }
    }
}

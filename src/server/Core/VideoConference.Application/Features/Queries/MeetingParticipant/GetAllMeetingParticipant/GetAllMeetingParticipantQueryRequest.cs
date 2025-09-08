using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Application.Features.Queries.Meeting.GetAllMeeting
{
    public class GetAllMeetingParticipantQueryRequest : IRequest<GetAllMeetingParticipantQueryResponse>
    {
        public Guid MeetingId { get; set; }
    }
}

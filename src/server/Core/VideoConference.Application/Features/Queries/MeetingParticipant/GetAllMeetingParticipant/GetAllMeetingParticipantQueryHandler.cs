using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Abstractions.Services;

namespace VideoConference.Application.Features.Queries.Meeting.GetAllMeeting
{
    public class GetAllMeetingParticipantQueryHandler : IRequestHandler<GetAllMeetingParticipantQueryRequest, GetAllMeetingParticipantQueryResponse>
    {
        private readonly IMeetingParticipantService _meetingParticipantService;

        public GetAllMeetingParticipantQueryHandler(IMeetingParticipantService meetingParticipantService)
        {
            _meetingParticipantService = meetingParticipantService;
        }

        public async Task<GetAllMeetingParticipantQueryResponse> Handle(GetAllMeetingParticipantQueryRequest request, CancellationToken cancellationToken)
        {
            var meetingParticipant = await _meetingParticipantService.GetAllByMeetingIdAsync(request.MeetingId);
            return new() { MeetingParticipants = meetingParticipant };
        }
    }
}

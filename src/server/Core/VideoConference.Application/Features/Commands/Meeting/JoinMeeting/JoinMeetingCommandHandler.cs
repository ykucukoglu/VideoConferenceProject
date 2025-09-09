using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Abstractions.Services;

namespace VideoConference.Application.Features.Commands.Meeting.JoinMeeting
{
    public class JoinMeetingCommandHandler : IRequestHandler<JoinMeetingCommandRequest, JoinMeetingCommandResponse>
    {
        private readonly IMeetingParticipantService _meetingParticipantService;

        public JoinMeetingCommandHandler(IMeetingParticipantService meetingParticipantService)
        {
            _meetingParticipantService = meetingParticipantService;
        }

        public async Task<JoinMeetingCommandResponse> Handle(JoinMeetingCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _meetingParticipantService.JoinMeetingAsync(request.MeetingId, request.UserId);
            return new() { MeetingId = response.MeetingId, UserId = response.UserId, Status = response.Status };
        }
    }
}

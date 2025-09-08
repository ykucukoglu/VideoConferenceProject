using MediatR;
using VideoConference.Application.Abstractions.Services;

namespace VideoConference.Application.Features.Commands.MeetingParticipants.JoinParticipant
{
    public class LeaveParticipantCommandHandler : IRequestHandler<LeaveParticipantCommandRequest, LeaveParticipantCommandResponse>
    {
        private readonly IMeetingParticipantService _meetingParticipantService;

        public LeaveParticipantCommandHandler(IMeetingParticipantService meetingParticipantService)
        {
            _meetingParticipantService = meetingParticipantService;
        }

        public async Task<LeaveParticipantCommandResponse> Handle(LeaveParticipantCommandRequest request, CancellationToken cancellationToken)
        {
            await _meetingParticipantService.UpdateParticipantStatusAsync(request.MeetingId, request.UserId, Domain.Enums.ParticipantStatus.Left);
            return new() { };
        }
    }
}

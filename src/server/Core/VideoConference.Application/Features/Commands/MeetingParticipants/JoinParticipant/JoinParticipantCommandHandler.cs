using MediatR;
using VideoConference.Application.Abstractions.Services;

namespace VideoConference.Application.Features.Commands.MeetingParticipants.JoinParticipant
{
    public class JoinParticipantCommandHandler : IRequestHandler<JoinParticipantCommandRequest, JoinParticipantCommandResponse>
    {
        private readonly IMeetingParticipantService _meetingParticipantService;

        public JoinParticipantCommandHandler(IMeetingParticipantService meetingParticipantService)
        {
            _meetingParticipantService = meetingParticipantService;
        }

        public async Task<JoinParticipantCommandResponse> Handle(JoinParticipantCommandRequest request, CancellationToken cancellationToken)
        {
            await _meetingParticipantService.UpdateParticipantStatusAsync(request.MeetingId, request.UserId, Domain.Enums.ParticipantStatus.Joined);
            return new() { };
        }
    }
}

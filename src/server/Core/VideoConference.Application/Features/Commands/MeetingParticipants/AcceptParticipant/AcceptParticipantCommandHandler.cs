using MediatR;
using VideoConference.Application.Abstractions.Services;

namespace VideoConference.Application.Features.Commands.MeetingParticipants.JoinParticipant
{
    public class AcceptParticipantCommandHandler : IRequestHandler<AcceptParticipantCommandRequest, AcceptParticipantCommandResponse>
    {
        private readonly IMeetingParticipantService _meetingParticipantService;

        public AcceptParticipantCommandHandler(IMeetingParticipantService meetingParticipantService)
        {
            _meetingParticipantService = meetingParticipantService;
        }

        public async Task<AcceptParticipantCommandResponse> Handle(AcceptParticipantCommandRequest request, CancellationToken cancellationToken)
        {
            await _meetingParticipantService.UpdateParticipantStatusAsync(request.MeetingId, request.UserId, Domain.Enums.ParticipantStatus.Approved);
            return new() { };
        }
    }
}

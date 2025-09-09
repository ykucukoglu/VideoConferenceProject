using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Abstractions.Services;

namespace VideoConference.Application.Features.Commands.MeetingParticipants.UpdateParticipant
{
    public class UpdateParticipantStatusCommandHandler : IRequestHandler<UpdateParticipantStatusCommandRequest, UpdateParticipantStatusCommandResponse>
    {
        private readonly IMeetingParticipantService _meetingParticipantService;

        public UpdateParticipantStatusCommandHandler(IMeetingParticipantService meetingParticipantService)
        {
            _meetingParticipantService = meetingParticipantService;
        }

        public async Task<UpdateParticipantStatusCommandResponse> Handle(UpdateParticipantStatusCommandRequest request, CancellationToken cancellationToken)
        {
            await _meetingParticipantService.UpdateParticipantStatusAsync(request.MeetingId, request.UserId, request.Status);
            return new() { };
        }
    }
}

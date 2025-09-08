using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Abstractions.Services;

namespace VideoConference.Application.Features.Commands.MeetingParticipants.InviteParticipant
{
    public class InviteParticipantCommandHandler : IRequestHandler<InviteParticipantCommandRequest, InviteParticipantCommandResponse>
    {
        private readonly IMeetingParticipantService _meetingParticipant;

        public InviteParticipantCommandHandler(IMeetingParticipantService meetingParticipant)
        {
            _meetingParticipant = meetingParticipant;
        }

        public async Task<InviteParticipantCommandResponse> Handle(InviteParticipantCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _meetingParticipant.AddAsync(new()
            {
                MeetingId = request.MeetingId,
                UserId = request.UserId
            });

            return new() {};
        }
    }
}

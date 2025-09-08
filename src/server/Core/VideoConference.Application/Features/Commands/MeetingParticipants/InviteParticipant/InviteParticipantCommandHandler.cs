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
        private readonly IInviteParticipantService _inviteParticipant;

        public InviteParticipantCommandHandler(IInviteParticipantService inviteParticipant)
        {
            _inviteParticipant = inviteParticipant;
        }

        public async Task<InviteParticipantCommandResponse> Handle(InviteParticipantCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _inviteParticipant.AddAsync(new()
            {
                MeetingId = request.MeetingId,
                UserId = request.UserId
            });

            return new() {};
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Application.Features.Commands.MeetingParticipants.JoinParticipant
{
    public class LeaveParticipantCommandRequest : IRequest<LeaveParticipantCommandResponse>
    {
        public Guid MeetingId { get; set; }
        public Guid UserId { get; set; }
    }
}

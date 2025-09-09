using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Domain.Enums;

namespace VideoConference.Application.Features.Commands.MeetingParticipants.UpdateParticipant
{
    public class UpdateParticipantStatusCommandRequest : IRequest<UpdateParticipantStatusCommandResponse>
    {
        public Guid MeetingId { get; set; }
        public Guid UserId { get; set; }
        public ParticipantStatus Status { get; set; }
    }
}

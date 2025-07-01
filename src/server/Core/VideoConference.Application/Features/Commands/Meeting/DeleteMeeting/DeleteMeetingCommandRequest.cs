using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Application.Features.Commands.Meeting.DeleteMeeting
{
    public class DeleteMeetingCommandRequest : IRequest<DeleteMeetingCommandResponse>
    {
        public Guid Id { get; set; }
    }
}

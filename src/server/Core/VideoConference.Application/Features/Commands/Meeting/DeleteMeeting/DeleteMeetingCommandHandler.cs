using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Abstractions.Services;

namespace VideoConference.Application.Features.Commands.Meeting.DeleteMeeting
{
    public class DeleteMeetingCommandHandler : IRequestHandler<DeleteMeetingCommandRequest, DeleteMeetingCommandResponse>
    {
        private readonly IMeetingService _meetingService;

        public DeleteMeetingCommandHandler(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        public async Task<DeleteMeetingCommandResponse> Handle(DeleteMeetingCommandRequest request, CancellationToken cancellationToken)
        {
            await _meetingService.DeleteMeetingAsync(request.Id);
            return new();
        }
    }
}

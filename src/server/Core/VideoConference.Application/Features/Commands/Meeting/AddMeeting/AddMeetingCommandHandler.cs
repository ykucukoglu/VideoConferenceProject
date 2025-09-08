using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Abstractions.Services;

namespace VideoConference.Application.Features.Commands.Meeting.AddMeeting
{
    public class AddMeetingCommandHandler : IRequestHandler<AddMeetingCommandRequest, AddMeetingCommandResponse>
    {
        private readonly IMeetingService _meetingService;

        public AddMeetingCommandHandler(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        public async Task<AddMeetingCommandResponse> Handle(AddMeetingCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _meetingService.AddAsync(new()
            {
                Title = request.Title,
                Description = request.Description,
                StartTime = request.StartTime,
                EndTime = request.EndTime
            });
            return new() { MeetingId = response };
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Abstractions.Services;

namespace VideoConference.Application.Features.Queries.Meeting.GetAllMeeting
{
    public class GetAllMeetingQueryHandler : IRequestHandler<GetAllMeetingQueryRequest, GetAllMeetingQueryResponse>
    {
        private readonly IMeetingService _meetingService;

        public GetAllMeetingQueryHandler(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        public async Task<GetAllMeetingQueryResponse> Handle(GetAllMeetingQueryRequest request, CancellationToken cancellationToken)
        {
            var meetings = await _meetingService.GetAllMeetingsAsync();
            return new() { Meetings = meetings };
        }
    }
}

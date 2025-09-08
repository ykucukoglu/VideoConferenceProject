using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Abstractions.Services;

namespace VideoConference.Application.Features.Queries.Meeting.GetByIdMeeting
{
    public class GetByIdMeetingQueryHandler : IRequestHandler<GetByIdMeetingQueryRequest, GetByIdMeetingQueryResponse>
    {
        private readonly IMeetingService _meetingService;

        public GetByIdMeetingQueryHandler(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        public async Task<GetByIdMeetingQueryResponse> Handle(GetByIdMeetingQueryRequest request, CancellationToken cancellationToken)
        {
            var meeting = await _meetingService.GetByIdAsync(request.Id);
            return new() {  MeetingId = meeting.Id };
        }
    }
}

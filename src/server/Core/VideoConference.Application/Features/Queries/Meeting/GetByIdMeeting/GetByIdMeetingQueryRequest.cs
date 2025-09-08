using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Application.Features.Queries.Meeting.GetByIdMeeting
{
    public class GetByIdMeetingQueryRequest : IRequest<GetByIdMeetingQueryResponse>
    {
        public Guid Id { get; set; }
    }
}

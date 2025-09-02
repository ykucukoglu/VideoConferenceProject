using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Application.Features.Queries.Community.GetByIdCommunity
{
    public class GetByIdCommunityQueryRequest : IRequest<GetByIdCommunityQueryResponse>
    {
        public Guid Id { get; set; }
    }
}

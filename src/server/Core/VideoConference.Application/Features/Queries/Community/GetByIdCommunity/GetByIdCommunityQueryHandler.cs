using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Abstractions.Services;

namespace VideoConference.Application.Features.Queries.Community.GetByIdCommunity
{
    public class GetByIdCommunityQueryHandler : IRequestHandler<GetByIdCommunityQueryRequest, GetByIdCommunityQueryResponse>
    {
        private readonly ICommunityService _communityService;

        public GetByIdCommunityQueryHandler(ICommunityService communityService)
        {
            _communityService = communityService;
        }

        public async Task<GetByIdCommunityQueryResponse> Handle(GetByIdCommunityQueryRequest request, CancellationToken cancellationToken)
        {
            var community =  await _communityService.GetByIdAsync(request.Id);
            return new()
            {
                Id = community.Id,
                Name = community.Name,
                OwnerId = community.OwnerId
            };
        }
    }
}

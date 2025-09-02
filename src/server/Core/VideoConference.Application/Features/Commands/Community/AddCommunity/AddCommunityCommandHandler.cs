using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Abstractions.Services;

namespace VideoConference.Application.Features.Commands.Community.AddCommunity
{
    public class AddCommunityCommandHandler : IRequestHandler<AddCommunityCommandRequest, AddCommunityCommandResponse>
    {
        private readonly ICommunityService _communityService;

        public AddCommunityCommandHandler(ICommunityService communityService)
        {
            _communityService = communityService;
        }

        public async Task<AddCommunityCommandResponse> Handle(AddCommunityCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _communityService.AddAsync(new()
            {
                Name = request.Name
            });

            return new() { CommunityId = response };
        }
    }
}

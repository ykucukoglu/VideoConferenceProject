using MediatR;
using VideoConference.Application.Abstractions.Services;

namespace VideoConference.Application.Features.Queries.Team.GetByIdTeam
{
    public class GetByIdTeamQueryHandler : IRequestHandler<GetByIdTeamQueryRequest, GetByIdTeamQueryResponse>
    {
        private readonly ITeamService _teamService;

        public GetByIdTeamQueryHandler(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<GetByIdTeamQueryResponse> Handle(GetByIdTeamQueryRequest request, CancellationToken cancellationToken)
        {
            var team = await _teamService.GetByIdAsync(request.Id);
            return new()
            {
                Id = team.Id,
                Name = team.Name,
                OrganizationId = team.OrganizationId
            };
        }
    }
}

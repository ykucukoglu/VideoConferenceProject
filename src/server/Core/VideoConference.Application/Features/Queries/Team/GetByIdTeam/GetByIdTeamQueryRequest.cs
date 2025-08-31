using MediatR;

namespace VideoConference.Application.Features.Queries.Team.GetByIdTeam
{
    public class GetByIdTeamQueryRequest : IRequest<GetByIdTeamQueryResponse>
    {
        public Guid Id { get; set; }
    }
}

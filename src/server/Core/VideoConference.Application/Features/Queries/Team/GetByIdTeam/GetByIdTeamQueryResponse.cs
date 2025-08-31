namespace VideoConference.Application.Features.Queries.Team.GetByIdTeam
{
    public class GetByIdTeamQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OrganizationId { get; set; }
    }
}

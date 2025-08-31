using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Abstractions.Services;

namespace VideoConference.Application.Features.Commands.Team.AddTeam
{
    public class AddTeamCommandHandler : IRequestHandler<AddTeamCommandRequest, AddTeamCommandResponse>
    {
        private readonly ITeamService _teamService;

        public AddTeamCommandHandler(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<AddTeamCommandResponse> Handle(AddTeamCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _teamService.AddAsync(new()
            {
                Name = request.Name
            });

            return new() { TeamId = response };
        }
    }
}

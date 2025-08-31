using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Application.Features.Commands.Team.AddTeam
{
    public class AddTeamCommandRequest : IRequest<AddTeamCommandResponse>
    {
        public string Name { get; set; }
    }
}

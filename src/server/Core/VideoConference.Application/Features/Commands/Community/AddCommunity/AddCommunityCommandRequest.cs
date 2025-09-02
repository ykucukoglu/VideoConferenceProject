using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Application.Features.Commands.Community.AddCommunity
{
    public class AddCommunityCommandRequest : IRequest<AddCommunityCommandResponse>
    {
        public string Name { get; set; }

    }
}

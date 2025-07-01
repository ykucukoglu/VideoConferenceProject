using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Application.Features.Commands.Auth.Revoke
{
    public class RevokeCommandRequest : IRequest<RevokeCommandResponse>
    {
        public string Email { get; set; }
    }
}

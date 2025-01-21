using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Application.Features.Commands.Auth.RevokeAll
{
    public class RevokeAllCommandRequest : IRequest<RevokeAllCommandResponse>
    {
    }
}

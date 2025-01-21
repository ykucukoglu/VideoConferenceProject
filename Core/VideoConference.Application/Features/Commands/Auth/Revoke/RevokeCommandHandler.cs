using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Abstractions.Services;

namespace VideoConference.Application.Features.Commands.Auth.Revoke
{
    public class RevokeCommandHandler : IRequestHandler<RevokeCommandRequest, RevokeCommandResponse>
    {
        private readonly IAuthService _authService;

        public RevokeCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<RevokeCommandResponse> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
        {
            await _authService.RevokeTokenAsync(request.Email);
            return new();
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Abstractions.Services;

namespace VideoConference.Application.Features.Commands.Auth.RevokeAll
{
    public class RevokeAllCommandHandler : IRequestHandler<RevokeAllCommandRequest, RevokeAllCommandResponse>
    {
        private readonly IAuthService _authService;

        public RevokeAllCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        async Task<RevokeAllCommandResponse> IRequestHandler<RevokeAllCommandRequest, RevokeAllCommandResponse>.Handle(RevokeAllCommandRequest request, CancellationToken cancellationToken)
        {
            await _authService.RevokeAllTokensAsync();
            return new();
        }
    }
}

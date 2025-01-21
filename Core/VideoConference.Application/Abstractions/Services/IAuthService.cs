using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Features.Commands.Auth.Login;
using VideoConference.Application.Features.Commands.Auth.RefreshToken;

namespace VideoConference.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<LoginCommandResponse> LoginAsync(string email, string password);
        Task<RefreshTokenCommandResponse> RefreshTokenAsync(string accessToken, string refreshToken);
        Task RevokeTokenAsync(string email);
        Task RevokeAllTokensAsync();
    }
}
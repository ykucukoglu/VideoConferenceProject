using Conference.WebApp.Models.Auth;

namespace Conference.WebApp.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
        //Task RefreshTokenAsync(RefreshTokenRequest request);
        Task RevokeAsync(RevokeRequest request);
        Task RevokeAllAsync();
    }
}

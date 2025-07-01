using Conference.WebApp.Models.Auth;
using Conference.WebApp.Services.Interfaces;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VideoConference.Application.Exceptions;

namespace Conference.WebApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/auth/login", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ExceptionModel>(errorResponse);

                // Hataları controller tarafında işlemek üzere döndürüyoruz
                return new LoginResponse
                {
                    Errors = (List<string>)errorModel.Errors // Hataları LoginResponse objesine ekliyoruz
                };
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseString);

            // Token'ı HttpContext'e ekleyin
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", loginResponse.Token);

            // ClaimsPrincipal oluşturma
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(loginResponse.Token);

            var identity = new ClaimsIdentity(jwtToken.Claims, "Bearer");
            var principal = new ClaimsPrincipal(identity);

            // Ensure Authorization header is only added once
            if (!_httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginResponse.Token);
            }

            _httpContextAccessor.HttpContext.Session.SetString("AccessToken", loginResponse.Token);

            return loginResponse;
        }


        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/auth/register", content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AuthResponse>(responseString);
        }

        //public async Task RefreshTokenAsync(RefreshTokenRequest request)
        //{
        //    var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
        //    var response = await _httpClient.PutAsync("api/auth/refresh-token", content);
        //    response.EnsureSuccessStatusCode();
        //}

        public async Task RevokeAsync(RevokeRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/auth/revoke", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task RevokeAllAsync()
        {
            var response = await _httpClient.PutAsync("api/auth/revoke-all", null);
            response.EnsureSuccessStatusCode();
        }
    }
}

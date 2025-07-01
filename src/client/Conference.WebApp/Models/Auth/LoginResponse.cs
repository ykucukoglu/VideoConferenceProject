namespace Conference.WebApp.Models.Auth
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public List<string> Errors { get; set; } = new List<string>(); // Hata mesajlarını tutacak liste

    }
}

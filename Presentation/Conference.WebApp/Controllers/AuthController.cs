using Conference.WebApp.Models.Auth;
using Conference.WebApp.Services;
using Conference.WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Conference.WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var response = await _authService.LoginAsync(request);

            if (response.Errors != null && response.Errors.Any()) // Hata varsa
            {
                foreach (var error in response.Errors)
                {
                    ModelState.AddModelError(string.Empty, error); // Hataları ModelState'e ekliyoruz
                }
                return View(request);
            }

            // Başarılı giriş işleminden sonra yapılacak işlemler
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var response = await _authService.RegisterAsync(request);
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await _authService.RevokeAllAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

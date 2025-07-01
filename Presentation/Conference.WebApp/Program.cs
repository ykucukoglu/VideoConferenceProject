using Conference.WebApp.Services;
using Conference.WebApp.Services.Handler;
using Conference.WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<AuthTokenHandler>();

// Add HttpClient for API communication.
builder.Services.AddHttpClient("WebApiClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/"); // API'nin temel adresini girin.
}).AddHttpMessageHandler<AuthTokenHandler>();

//// Scoped HttpClient injection.
builder.Services.AddScoped(sp =>
{
    var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
    return clientFactory.CreateClient("WebApiClient");
});
// Scoped HttpClient injection for MeetingService and AuthService
//builder.Services.AddHttpClient<IMeetingService, MeetingService>("WebApiClient", client =>
//{
//    client.BaseAddress = new Uri("http://localhost:5000/");
//});

//builder.Services.AddHttpClient<IAuthService, AuthService>("WebApiClient", client =>
//{
//    client.BaseAddress = new Uri("http://localhost:5000/");
//});
// Add Application Services (Dependency Injection for Auth and Meeting Services)
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IMeetingService, MeetingService>();
builder.Services.AddHttpContextAccessor();

// Add Session support (optional)
builder.Services.AddSession();

// Add Authentication and Authorization (optional, if API requires it)
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = "http://localhost:5000"; // API base URL
    options.Audience = "http://localhost:5000"; // API audience
    options.RequireHttpsMetadata = false;         // Disable HTTPS requirement in development
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

// Middleware configuration
app.UseRouting();


app.UseAuthentication(); // Kimlik doðrulama middleware
app.UseAuthorization(); // Yetkilendirme middleware
app.UseSession(); // Oturum desteðini etkinleþtirin.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

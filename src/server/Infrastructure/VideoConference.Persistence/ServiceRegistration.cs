using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Abstractions.Services;
using VideoConference.Application.Repositories;
using VideoConference.Application.Repositories.UnitOfWorks;
using VideoConference.Domain.Entities;
using VideoConference.Persistence.Contexts;
using VideoConference.Persistence.Repositories;
using VideoConference.Persistence.Services;
using VideoConference.Persistence.UnitOfWorks;

namespace VideoConference.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMeetingService, MeetingService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<ICommunityService, CommunityService>();
            services.AddScoped<IMeetingParticipantService, MeetingParticipantService>();

            services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 2;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.SignIn.RequireConfirmedEmail = false;
            })
           .AddRoles<Role>()
           .AddEntityFrameworkStores<AppDbContext>();
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Abstractions.Services;
using VideoConference.Application.Features.Commands.Auth.Register;
using VideoConference.Application.Features.Rules.Auth;
using VideoConference.Domain.Entities;

namespace VideoConference.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly AuthRules _authRules;
        private readonly IMapper _mapper;
        public UserService(UserManager<User> userManager, RoleManager<Role> roleManager, AuthRules authRules, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _authRules = authRules;
            _mapper = mapper;
        }

        public async Task<RegisterCommandResponse> CreateAsync(RegisterCommandRequest register)
        {
            await _authRules.UserShouldNotBeExist(await _userManager.FindByEmailAsync(register.Email));

            User user = _mapper.Map<User>(register);
            user.UserName = register.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = await _userManager.CreateAsync(user, register.Password);

            if (result.Succeeded)
            {
                if(!await _roleManager.RoleExistsAsync("User"))
                {
                    await _roleManager.CreateAsync(new Role()
                    {
                        Id = Guid.NewGuid(),
                        Name = "User",
                        NormalizedName = "USER",
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                    });
                }

                await _userManager.AddToRoleAsync(user,"User");
            }

            return new();
        }
    }
}

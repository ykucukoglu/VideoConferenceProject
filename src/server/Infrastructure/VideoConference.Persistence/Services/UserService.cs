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
using VideoConference.Domain.Enums;

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
                await _userManager.AddToRoleAsync(user,"User");

                if (!await _roleManager.RoleExistsAsync(SystemRole.Guest.Name))
                {
                    await _roleManager.CreateAsync(Role.Create(SystemRole.Guest.Name));
                }

                // Kullanıcıya rol ata
                await _userManager.AddToRoleAsync(user, SystemRole.Guest.Name);

            }

            return new();
        }
    }
}

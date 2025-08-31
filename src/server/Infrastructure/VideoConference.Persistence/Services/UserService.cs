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
using VideoConference.Application.Repositories.UnitOfWorks;
using VideoConference.Domain.Constants;
using VideoConference.Domain.Entities;

namespace VideoConference.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly AuthRules _authRules;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(UserManager<User> userManager, RoleManager<Role> roleManager, AuthRules authRules, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _authRules = authRules;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<RegisterCommandResponse> CreateAsync(RegisterCommandRequest register)
        {
            await _authRules.UserShouldNotBeExist(await _userManager.FindByEmailAsync(register.Email));

            User user = _mapper.Map<User>(register);
            user.UserName = register.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
                throw new Exception("User creation failed");

            //Default Organization oluştur
            var organization = new Organization
            {
                Name = $"{register.Email}'s Organization",
                OwnerId = user.Id
            };

            await _unitOfWork.GetWriteRepository<Organization>().AddAsync(organization);
            var orgOwnerRole = await _roleManager.FindByNameAsync(RoleConstants.OrganizationOwner);

            if (orgOwnerRole == null)
                throw new Exception("OrganizationOwner rolü bulunamadı.");

            var orgOwnerUserRole = new UserRole
            {
                UserId = user.Id,
                RoleId = orgOwnerRole.Id,
                ScopeId = organization.Id  // kendi org’u scope
            };

            await _unitOfWork.GetWriteRepository<UserRole>().AddAsync(orgOwnerUserRole);

            await _unitOfWork.SaveAsync();

            return new();
        }
    }
}

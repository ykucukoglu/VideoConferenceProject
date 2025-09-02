using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Abstractions.Services;
using VideoConference.Application.DTOs.Communities;
using VideoConference.Application.Extensions;
using VideoConference.Application.Features.Rules.Community;
using VideoConference.Application.Features.Rules.Team;
using VideoConference.Application.Repositories.UnitOfWorks;
using VideoConference.Domain.Constants;
using VideoConference.Domain.Entities;

namespace VideoConference.Persistence.Services
{
    public class CommunityService : ICommunityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommunityRules _communityRules;

        public CommunityService(IUnitOfWork unitOfWork, IMapper mapper, RoleManager<Role> roleManager, IHttpContextAccessor httpContextAccessor, CommunityRules communityRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
            _communityRules = communityRules;
        }

        public async Task<Guid> AddAsync(AddCommunityDTO communityDTO)
        {
            var user = _httpContextAccessor.HttpContext?.User ?? throw new Exception("User not found in HttpContext");
            var userId = user.GetLoggedInUserId();
            await _communityRules.CommunityNameMustNotBeSame(userId, communityDTO.Name);
            var community = new Community
            {
                Name = communityDTO.Name,
                OwnerId = userId
            };
            await _unitOfWork.GetWriteRepository<Community>().AddAsync(community);

            var communityOwnerRole = await _roleManager.FindByNameAsync(RoleConstants.CommunityOwner);
            if (communityOwnerRole == null)
                throw new Exception("communityOwner rolü bulunamadı.");

            var communityOwnerUserRole = new UserRole
            {
                UserId = userId,
                RoleId = communityOwnerRole.Id,
                ScopeId = community.Id
            };
            await _unitOfWork.GetWriteRepository<UserRole>().AddAsync(communityOwnerUserRole);
            await _unitOfWork.SaveAsync();
            return community.Id;

        }

        public async Task<CommunityDTO> GetByIdAsync(Guid communityId)
        {
            var community = await _unitOfWork.GetReadRepository<Community>().GetAsync(x => x.Id == communityId && !x.IsDeleted);
            return _mapper.Map<CommunityDTO>(community);
        }
    }
}

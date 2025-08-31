using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Abstractions.Services;
using VideoConference.Application.DTOs.Teams;
using VideoConference.Application.Extensions;
using VideoConference.Application.Features.Rules.Team;
using VideoConference.Application.Repositories.UnitOfWorks;
using VideoConference.Domain.Constants;
using VideoConference.Domain.Entities;

namespace VideoConference.Persistence.Services
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TeamRules _teamRules;
        public TeamService(IUnitOfWork unitOfWork, IMapper mapper, RoleManager<Role> roleManager, IHttpContextAccessor httpContextAccessor, TeamRules teamRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
            _teamRules = teamRules;
        }

        public async Task<Guid> AddAsync(AddTeamDTO teamDTO)
        {
            var user = _httpContextAccessor.HttpContext?.User ?? throw new Exception("User not found in HttpContext");

            var userId = user.GetLoggedInUserId();

            var organization = await _unitOfWork.GetReadRepository<Organization>().GetAsync(x => x.OwnerId == userId && !x.IsDeleted);

            await _teamRules.TeamNameMustNotBeSameInOrganization(organization.Id, teamDTO.Name);

            var team = new Team
            {
                Name = teamDTO.Name,
                OrganizationId = organization.Id
            };
            await _unitOfWork.GetWriteRepository<Team>().AddAsync(team);

            var teamOwnerRole = await _roleManager.FindByNameAsync(RoleConstants.TeamOwner);
            if (teamOwnerRole == null)
                throw new Exception("teamOwner rolü bulunamadı.");

            var teamOwnerUserRole = new UserRole
            {
                UserId = userId,
                RoleId = teamOwnerRole.Id,
                ScopeId = team.Id
            };
            await _unitOfWork.GetWriteRepository<UserRole>().AddAsync(teamOwnerUserRole);

            await _unitOfWork.SaveAsync();

            return team.Id;
        }

        public async Task<TeamDTO> GetByIdAsync(Guid teamId)
        {
            var team = await _unitOfWork.GetReadRepository<Team>().GetAsync(x => x.Id == teamId && !x.IsDeleted);
            return _mapper.Map<TeamDTO>(team);
        }
    }
}

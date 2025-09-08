using Microsoft.AspNetCore.Identity;
using VideoConference.Application.Abstractions.Services;
using VideoConference.Application.DTOs.InviteParticipants;
using VideoConference.Application.Features.Rules.MeetingParticipant;
using VideoConference.Application.Features.Rules.User;
using VideoConference.Application.Repositories.UnitOfWorks;
using VideoConference.Domain.Constants;
using VideoConference.Domain.Entities;
using VideoConference.Domain.Enums;

namespace VideoConference.Persistence.Services
{
    public class InviteParticipantService : IInviteParticipantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserRules _userRules;
        private readonly InviteParticipantRules _inviteParticipantRules;

        public InviteParticipantService(IUnitOfWork unitOfWork, RoleManager<Role> roleManager, UserRules userRules, InviteParticipantRules inviteParticipantRules)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userRules = userRules;
            _inviteParticipantRules = inviteParticipantRules;
        }

        public async Task<Guid> AddAsync(AddInviteDTO dto)
        {
            await _inviteParticipantRules.ValidateMeetingExists(dto.MeetingId);
            await _userRules.ValidateUserExists(dto.UserId);

            var role = await _roleManager.FindByNameAsync(RoleConstants.MeetingParticipant);
            if (role == null)
                throw new Exception("MeetingParticipant rolü bulunamadı.");

            var invite = new MeetingParticipant
            {
                MeetingId = dto.MeetingId,
                UserId = dto.UserId,
                RoleId = role.Id,
                Status = ParticipantStatus.Pending
            };

            await _unitOfWork.GetWriteRepository<MeetingParticipant>().AddAsync(invite);
            await _unitOfWork.SaveAsync();
            return invite.Id;
        }
    }
}

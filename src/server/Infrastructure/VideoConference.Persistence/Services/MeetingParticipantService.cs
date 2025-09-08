using AutoMapper;
using Microsoft.AspNetCore.Identity;
using VideoConference.Application.Abstractions.Services;
using VideoConference.Application.DTOs.InviteParticipants;
using VideoConference.Application.DTOs.MeetingParticipants;
using VideoConference.Application.Features.Rules.MeetingParticipant;
using VideoConference.Application.Features.Rules.User;
using VideoConference.Application.Repositories.UnitOfWorks;
using VideoConference.Domain.Constants;
using VideoConference.Domain.Entities;
using VideoConference.Domain.Enums;

namespace VideoConference.Persistence.Services
{
    public class MeetingParticipantService : IMeetingParticipantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserRules _userRules;
        private readonly InviteParticipantRules _inviteParticipantRules;
        private readonly IMapper _mapper;

        public MeetingParticipantService(IUnitOfWork unitOfWork, RoleManager<Role> roleManager, UserRules userRules, InviteParticipantRules inviteParticipantRules, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userRules = userRules;
            _inviteParticipantRules = inviteParticipantRules;
            _mapper = mapper;
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

        public async Task<List<MeetingParticipantDTO>> GetAllByMeetingIdAsync(Guid meetingId)
        {
            var participants = await _unitOfWork.GetReadRepository<MeetingParticipant>().GetAsync(
                p => p.MeetingId == meetingId && !p.IsDeleted
            );
            return _mapper.Map<List<MeetingParticipantDTO>>(participants);
        }

        public async Task UpdateParticipantStatusAsync(Guid meetingId, Guid userId, ParticipantStatus status)
        {
            var participant = await _unitOfWork.GetReadRepository<MeetingParticipant>().GetAsync
                (p => p.MeetingId == meetingId && p.UserId == userId && !p.IsDeleted);

            participant.Status = status;
            await _unitOfWork.GetWriteRepository<MeetingParticipant>().UpdateAsync(participant);
            await _unitOfWork.SaveAsync();
        }
    }
}

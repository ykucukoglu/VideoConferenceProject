using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Abstractions.Services;
using VideoConference.Application.DTOs.Meetings;
using VideoConference.Application.Extensions;
using VideoConference.Application.Repositories.UnitOfWorks;
using VideoConference.Domain.Constants;
using VideoConference.Domain.Entities;
using VideoConference.Domain.Enums;
using VideoConference.Persistence.UnitOfWorks;

namespace VideoConference.Persistence.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly RoleManager<Role> _roleManager;
        public MeetingService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, RoleManager<Role> roleManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _roleManager = roleManager;
        }

        public async Task<Guid> AddAsync(AddMeetingDTO meetingDTO)
        {
            var user = _httpContextAccessor.HttpContext?.User ?? throw new Exception("User not found in HttpContext");
            var userId = user.GetLoggedInUserId();

            var role = await _roleManager.FindByNameAsync(RoleConstants.MeetingOrganizer);
            var meeting = _mapper.Map<Meeting>(meetingDTO);
            meeting.OrganizerId = userId;
            meeting.Participants = new List<MeetingParticipant>
            {
                new MeetingParticipant
                {
                    UserId = userId,
                    RoleId = role.Id,
                    Status = ParticipantStatus.Pending
                }
            };

            await _unitOfWork.GetWriteRepository<Meeting>().AddAsync(meeting);
            await _unitOfWork.SaveAsync();
            return meeting.Id;
        }

        public async Task DeleteMeetingAsync(Guid meetingId)
        {
            var meeting = await _unitOfWork.GetReadRepository<Meeting>().GetAsync(x => x.Id == meetingId && !x.IsDeleted);
            if (meeting != null)
            {
                meeting.IsDeleted = true;

                await _unitOfWork.GetWriteRepository<Meeting>().UpdateAsync(meeting);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<List<MeetingDTO>> GetAllMeetingsAsync()
        {
            var meets = await _unitOfWork.GetReadRepository<Meeting>().GetAll().ToListAsync();
            return _mapper.Map<List<MeetingDTO>>(meets);
        }

        public async Task<MeetingDTO> GetByIdAsync(Guid meetingId)
        {
            var meeting = await _unitOfWork.GetReadRepository<Meeting>().GetAsync(x => x.Id == meetingId && !x.IsDeleted);
            return _mapper.Map<MeetingDTO>(meeting);
        }
    }
}

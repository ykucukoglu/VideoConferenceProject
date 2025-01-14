using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Abstractions.Services;
using VideoConference.Application.DTOs.Meetings;
using VideoConference.Application.Repositories.UnitOfWorks;
using VideoConference.Domain.Entities;

namespace VideoConference.Persistence.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MeetingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MeetingDTO>> GetAllMeetingsAsync()
        {
            var meets = await _unitOfWork.GetReadRepository<Meeting>().GetAllAsync();
            return _mapper.Map<List<MeetingDTO>>(meets);
        }
    }
}

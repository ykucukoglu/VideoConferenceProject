using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.DTOs.Meetings;

namespace VideoConference.Application.Abstractions.Services
{
    public interface IMeetingService
    {
        Task<List<MeetingDTO>> GetAllMeetingsAsync();
        public Task DeleteMeetingAsync(Guid meetingId);
        Task<MeetingDTO> GetByIdAsync(Guid meetingId);
        Task<Guid> AddAsync(AddMeetingDTO meetingDTO);
    }
}

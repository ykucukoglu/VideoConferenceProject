using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.DTOs.InviteParticipants;
using VideoConference.Application.DTOs.MeetingParticipants;
using VideoConference.Domain.Entities;
using VideoConference.Domain.Enums;

namespace VideoConference.Application.Abstractions.Services
{
    public interface IMeetingParticipantService
    {
        Task<Guid> AddAsync(AddInviteDTO dto);
        Task UpdateParticipantStatusAsync(Guid meetingId, Guid userId, ParticipantStatus status);
        Task<List<MeetingParticipantDTO>> GetAllByMeetingIdAsync(Guid meetingId);
        Task<MeetingParticipant> JoinMeetingAsync(Guid meetingId, Guid userId);
    }
}

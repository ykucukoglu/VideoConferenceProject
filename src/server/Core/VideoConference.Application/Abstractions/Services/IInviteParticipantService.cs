using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.DTOs.InviteParticipants;

namespace VideoConference.Application.Abstractions.Services
{
    public interface IInviteParticipantService
    {
        Task<Guid> AddAsync(AddInviteDTO dto);
    }
}

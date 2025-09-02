using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.DTOs.Communities;
using VideoConference.Application.DTOs.Teams;

namespace VideoConference.Application.Abstractions.Services
{
    public interface ICommunityService
    {
        Task<CommunityDTO> GetByIdAsync(Guid communityId);
        Task<Guid> AddAsync(AddCommunityDTO communityDTO);
    }
}

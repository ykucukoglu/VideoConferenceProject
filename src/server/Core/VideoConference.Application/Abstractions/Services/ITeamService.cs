using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.DTOs.Teams;

namespace VideoConference.Application.Abstractions.Services
{
    public interface ITeamService
    {
        Task<TeamDTO> GetByIdAsync(Guid teamId);
        Task<Guid> AddAsync(AddTeamDTO teamDTO);
    }
}

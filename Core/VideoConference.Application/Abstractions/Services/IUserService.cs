using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Features.Commands.Auth.Register;

namespace VideoConference.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<RegisterCommandResponse> CreateAsync(RegisterCommandRequest register);
    }
}

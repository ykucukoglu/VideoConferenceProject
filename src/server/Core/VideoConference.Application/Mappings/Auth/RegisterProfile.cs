using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.DTOs.Meetings;
using VideoConference.Application.Features.Commands.Auth.Register;
using VideoConference.Domain.Entities;

namespace VideoConference.Application.Mappings.Auth
{
    public class RegisterProfile : Profile
    {
        public RegisterProfile()
        {
            CreateMap<RegisterCommandRequest, User>().ReverseMap();
        }
    }
}

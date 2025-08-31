using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.DTOs.Teams;
using VideoConference.Domain.Entities;

namespace VideoConference.Application.Mappings.Teams
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<TeamDTO, Team>().ReverseMap();
        }
    }
}

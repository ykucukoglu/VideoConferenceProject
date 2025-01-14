using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.DTOs.Meetings;
using VideoConference.Domain.Entities;

namespace VideoConference.Application.Mappings.Meetings
{
    public class MeetingProfile : Profile
    {
        public MeetingProfile()
        {
            CreateMap<MeetingDTO, Meeting>().ReverseMap();
        }
    }
}

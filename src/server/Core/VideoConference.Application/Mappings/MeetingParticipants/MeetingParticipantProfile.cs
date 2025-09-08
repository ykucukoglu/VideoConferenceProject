using AutoMapper;
using VideoConference.Application.DTOs.MeetingParticipants;
using VideoConference.Domain.Entities;

namespace VideoConference.Application.Mappings.MeetingParticipants
{
    public class MeetingParticipantProfile : Profile
    {
        public MeetingParticipantProfile()
        {
            CreateMap<MeetingParticipant, MeetingParticipantDTO>().ReverseMap();
        }
    }
}

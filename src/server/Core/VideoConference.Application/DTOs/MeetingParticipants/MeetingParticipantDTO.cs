using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Domain.Entities;
using VideoConference.Domain.Enums;

namespace VideoConference.Application.DTOs.MeetingParticipants
{
    public class MeetingParticipantDTO
    {
        public Guid MeetingId { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public ParticipantStatus Status { get; set; }
    }
}

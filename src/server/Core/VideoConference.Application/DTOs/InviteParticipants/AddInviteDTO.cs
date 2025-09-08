using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Application.DTOs.InviteParticipants
{
    public class AddInviteDTO
    {
        public Guid MeetingId { get; set; }
        public Guid UserId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Domain.Entities.Common;

namespace VideoConference.Domain.Entities
{
    public class MeetingSetting : BaseEntity
    {
        public Guid Id { get; set; }
        public bool AllowRecording { get; set; }
        public int MaxParticipants { get; set; }
        public Guid MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}

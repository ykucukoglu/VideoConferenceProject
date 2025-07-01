using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Domain.Entities.Common;

namespace VideoConference.Domain.Entities
{
    public class Meeting : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CreatedBy { get; set; } // FK to IdentityUser
        public DateTime CreatedAt { get; set; }
        public Guid SettingId { get; set; }
        public MeetingSetting Settings { get; set; }
    }
}

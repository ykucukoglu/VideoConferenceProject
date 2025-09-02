using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Domain.Common;

namespace VideoConference.Domain.Entities
{
    public class Community : BaseEntity
    {
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }
        public ICollection<CommunityMember>? Members { get; set; }

        public ICollection<Channel>? Channels { get; set; }
    }
}

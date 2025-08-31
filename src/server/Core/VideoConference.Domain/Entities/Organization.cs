using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Domain.Common;

namespace VideoConference.Domain.Entities
{
    public class Organization: BaseEntity
    {
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Domain.Common;

namespace VideoConference.Domain.Entities
{
    public class UserRole : IdentityUserRole<Guid>, IBaseEntity
    {
        public User User { get; set; }
        public Role Role { get; set; }
        public Guid ScopeId { get; set; }  // OrganizationId, TeamId veya ChannelId

    }
}

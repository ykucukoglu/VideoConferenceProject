using Microsoft.AspNetCore.Identity;
using VideoConference.Domain.Common;
using VideoConference.Domain.Enums;

namespace VideoConference.Domain.Entities
{
    public class Role : IdentityRole<Guid>, IBaseEntity
    {
        public RoleScope Scope { get; set; }
        public ICollection<UserRole>? UserRoles { get; set; }
    }
}

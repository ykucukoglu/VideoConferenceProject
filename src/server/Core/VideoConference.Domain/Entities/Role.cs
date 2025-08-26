using Microsoft.AspNetCore.Identity;
using VideoConference.Domain.Primitives;

namespace VideoConference.Domain.Entities
{
    public class Role : IdentityRole<Guid>, IBaseEntity
    {
        protected Role() { }
        private Role(string name) : base(name)
        {
            Id = Guid.NewGuid();
            NormalizedName = name.ToUpperInvariant();
            ConcurrencyStamp = Guid.NewGuid().ToString();
        }

        public static Role Create(string name) => new Role(name);
    }
}

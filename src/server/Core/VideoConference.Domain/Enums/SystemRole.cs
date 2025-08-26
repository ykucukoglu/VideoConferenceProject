using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Domain.Primitives;

namespace VideoConference.Domain.Enums
{
    public class SystemRole : EnumerationBase
    {
        public static readonly SystemRole GlobalAdmin = new(1, "GlobalAdmin");
        public static readonly SystemRole OrganizationOwner = new(2, "OrganizationOwner");
        public static readonly SystemRole Guest = new(3, "Guest");

        private SystemRole(int id, string name) : base(id, name) { }
    }
}

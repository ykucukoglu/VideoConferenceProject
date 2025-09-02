using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Domain.Enums
{
    public enum RoleScope : byte
    {
        Channel = 0,
        Chat = 1,
        Meeting = 2,
        System = 3,
        Team = 4,
        Oganization = 5,
        Community = 6
    }

}

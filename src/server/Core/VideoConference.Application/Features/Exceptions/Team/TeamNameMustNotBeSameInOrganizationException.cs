using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Bases;

namespace VideoConference.Application.Features.Exceptions.Team
{
    public class TeamNameMustNotBeSameInOrganizationException : BaseException
    {
        public TeamNameMustNotBeSameInOrganizationException() : base("Takım adı aynı organizasyonda zaten mevcut.") { }

    }
}

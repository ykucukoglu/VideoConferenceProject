using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Domain.Primitives
{
    public interface IBaseEntity
    {
        Guid Id { get; }
    }
}

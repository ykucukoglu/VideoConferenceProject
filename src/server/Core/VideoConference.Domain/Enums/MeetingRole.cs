using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Domain.Primitives;

namespace VideoConference.Domain.Enums
{
    public sealed class MeetingRole : EnumerationBase
    {
        public static readonly MeetingRole Organizer = new(1, "Organizer");
        public static readonly MeetingRole CoHost = new(2, "CoHost");
        public static readonly MeetingRole Participant = new(3, "Participant");

        private MeetingRole(int id, string name) : base(id, name) { }
        public static MeetingRole FromId(int id)
        {
            return id switch
            {
                1 => Organizer,
                2 => Participant,
                _ => throw new ArgumentException($"Invalid MeetingRole id: {id}")
            };
        }
    }
}

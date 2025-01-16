using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Bases;

namespace VideoConference.Application.Features.Exceptions.Meeting
{
    public class MeetingTitleMustNotBeSameException : BaseException
    {
        public MeetingTitleMustNotBeSameException() : base("Toplantı başlığı zaten var!") { }
    }
}

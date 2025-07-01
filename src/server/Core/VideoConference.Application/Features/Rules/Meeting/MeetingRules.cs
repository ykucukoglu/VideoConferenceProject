using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Bases;
using VideoConference.Application.Features.Exceptions.Meeting;
using VideoConference.Domain.Entities;

namespace VideoConference.Application.Features.Rules.Meeting
{
    public class MeetingRules : BaseRules
    {
        public Task MeetingTitleMustNotBeSame(IList<VideoConference.Domain.Entities.Meeting> meetings, string requestTitle)
        {
            if (meetings.Any(x => x.Title == requestTitle)) throw new MeetingTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}

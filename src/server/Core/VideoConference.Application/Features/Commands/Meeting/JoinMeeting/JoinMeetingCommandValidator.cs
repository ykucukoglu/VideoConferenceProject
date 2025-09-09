using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Application.Features.Commands.Meeting.JoinMeeting
{
    public class JoinMeetingCommandValidator : AbstractValidator<JoinMeetingCommandRequest>
    {
        public JoinMeetingCommandValidator()
        {
            RuleFor(x => x.MeetingId).NotEmpty().NotNull();
            RuleFor(x => x.UserId).NotEmpty().NotNull();
        }
    }
}

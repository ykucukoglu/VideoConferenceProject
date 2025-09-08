using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Application.Features.Commands.MeetingParticipants.JoinParticipant
{
    public class JoinParticipantCommandValidator :AbstractValidator<JoinParticipantCommandRequest>
    {
        public JoinParticipantCommandValidator()
        {
            RuleFor(x => x.MeetingId).NotEmpty().NotNull();
            RuleFor(x => x.UserId).NotEmpty().NotNull();
        }
    }
}

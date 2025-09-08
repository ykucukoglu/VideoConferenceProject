using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Application.Features.Commands.MeetingParticipants.InviteParticipant
{
    public class InviteParticipantCommandValidator : AbstractValidator<InviteParticipantCommandRequest>
    {
        public InviteParticipantCommandValidator()
        {
            RuleFor(x => x.MeetingId).NotEmpty().NotNull();
            RuleFor(x => x.UserId).NotEmpty().NotNull();
        }
    }
}

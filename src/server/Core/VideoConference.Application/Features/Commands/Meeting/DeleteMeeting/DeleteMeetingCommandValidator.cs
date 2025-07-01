using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Application.Features.Commands.Meeting.DeleteMeeting
{
    public class DeleteMeetingCommandValidator : AbstractValidator<DeleteMeetingCommandRequest>
    {
        public DeleteMeetingCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}

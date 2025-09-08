using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Application.Features.Commands.Meeting.AddMeeting
{
    public class AddMeetingCommandValidator : AbstractValidator<AddMeetingCommandRequest>
    {
        public AddMeetingCommandValidator()
        {
            RuleFor(RuleFor => RuleFor.Title).NotEmpty().MaximumLength(200);
            RuleFor(m => m.Description);
            RuleFor(m => m.StartTime).NotEmpty().Must(BeAValidDate);

            RuleFor(m => m.EndTime).NotEmpty().Must(BeAValidDate).GreaterThan(m => m.StartTime);
        }
        private bool BeAValidDate(DateTime date)
        {
            return date != default;
        }
    }
}

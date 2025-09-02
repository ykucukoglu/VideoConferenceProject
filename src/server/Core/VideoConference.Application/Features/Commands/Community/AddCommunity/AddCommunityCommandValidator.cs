using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Application.Features.Commands.Community.AddCommunity
{
    public class AddCommunityCommandValidator : AbstractValidator<AddCommunityCommandRequest>
    {
        public AddCommunityCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(100);
        }
    }
}

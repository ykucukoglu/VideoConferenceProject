using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Application.Features.Commands.Team.AddTeam
{
    public class AddTeamCommandValidator : AbstractValidator<AddTeamCommandRequest>
    {
        public AddTeamCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(100);
        }
    }
}

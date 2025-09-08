using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Bases;
using VideoConference.Application.Features.Exceptions.MeetingParticipant;
using VideoConference.Application.Repositories.UnitOfWorks;

namespace VideoConference.Application.Features.Rules.MeetingParticipant
{
    public class InviteParticipantRules : BaseRules
    {
        private readonly IUnitOfWork _unitOfWork;

        public InviteParticipantRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ValidateMeetingExists(Guid meetingId)
        {
            var exists = await _unitOfWork.GetReadRepository<Domain.Entities.Meeting>()
                        .AnyAsync(x => x.Id == meetingId && !x.IsDeleted);
            if (!exists)
                throw new ValidateMeetingExistsException();
        }
    }
}

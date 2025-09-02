using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Bases;
using VideoConference.Application.Features.Exceptions.Community;
using VideoConference.Application.Repositories.UnitOfWorks;

namespace VideoConference.Application.Features.Rules.Community
{
    public class CommunityRules : BaseRules
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommunityRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CommunityNameMustNotBeSame(Guid userId, string name)
        {
            //var existingCommunity = await _unitOfWork.GetReadRepository<Domain.Entities.Community>()
            //    .GetAsync(x => x.OwnerId == userId && x.Name == name && !x.IsDeleted);
            //if (existingCommunity != null)
            //    throw new CommunityNameMustNotBeSameException();

            var exists = await _unitOfWork.GetReadRepository<Domain.Entities.Community>()
                        .AnyAsync(x => x.OwnerId == userId && x.Name == name && !x.IsDeleted);

            if (exists)
                throw new CommunityNameMustNotBeSameException();
        }
    }
}

using VideoConference.Application.Bases;
using VideoConference.Application.Features.Exceptions.User;
using VideoConference.Application.Repositories.UnitOfWorks;

namespace VideoConference.Application.Features.Rules.User
{
    public class UserRules : BaseRules
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task ValidateUserExists(Guid userId)
        {
            var exists = await _unitOfWork.GetReadRepository<Domain.Entities.User>()
                        .AnyAsync(x => x.Id == userId);
            if (!exists)
                throw new ValidateUserExistsException();
        }
    }
}

using VideoConference.Application.Bases;
using VideoConference.Application.Repositories.UnitOfWorks;
using VideoConference.Domain.Entities;
using DomainTeam = VideoConference.Domain.Entities.Team;


namespace VideoConference.Application.Features.Rules.Team
{
    public class TeamRules : BaseRules
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task TeamNameMustNotBeSameInOrganization(Guid orgId, string name)
        {
            var existingTeam = await _unitOfWork.GetReadRepository<DomainTeam> ()
                .GetAsync(x => x.OrganizationId == orgId && x.Name == name && !x.IsDeleted);
            if (existingTeam != null)
                throw new Exception("Takım adı aynı organizasyonda zaten mevcut.");
        }

        //public Task TeamMustExist(DomainTeam team)
        //{
        //    if (team == null) throw new Exception("Takım bulunamadı.");
        //    return Task.CompletedTask;
        //}

        //public Task UserMustHaveAccessToTeam(Guid userId, DomainTeam team, ICollection<UserRole> userRoles)
        //{
        //    var hasAccess = userRoles.Any(x => x.UserId == userId && x.ScopeId == team.Id);
        //    if (!hasAccess) throw new Exception("Bu takıma erişim yetkiniz yok.");
        //    return Task.CompletedTask;
        //}

    }

}

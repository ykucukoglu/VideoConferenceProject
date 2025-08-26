using VideoConference.Domain.Enums;
using VideoConference.Domain.Primitives;

namespace VideoConference.Domain.Entities
{
    public class Team : BaseEntity
    {
        public string Name { get; private set; }
        public ICollection<TeamMember> Members { get; private set; } = new List<TeamMember>();
        public ICollection<Channel> Channels { get; private set; } = new List<Channel>();

        protected Team() { }

        private Team(string name) => Name = name;

        public static Team Create(string name) => new Team(name);

        public void AddMember(Guid userId, TeamRole role)
        {
            Members.Add(new TeamMember(userId, Id, role));
        }
    }
}


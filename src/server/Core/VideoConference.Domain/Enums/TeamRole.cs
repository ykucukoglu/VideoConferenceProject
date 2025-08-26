using VideoConference.Domain.Primitives;

namespace VideoConference.Domain.Enums
{
    public sealed class TeamRole : EnumerationBase
    {
        public static readonly TeamRole Owner = new(1, "Owner");
        public static readonly TeamRole Member = new(2, "Member");

        private TeamRole(int id, string name) : base(id, name) { }
        public static TeamRole FromId(int id)
        {
            return id switch
            {
                1 => Owner,
                2 => Member,
                _ => throw new ArgumentException($"Invalid TeamRole id: {id}")
            };
        }
    }
}

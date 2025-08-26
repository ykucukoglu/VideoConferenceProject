using VideoConference.Domain.Primitives;

namespace VideoConference.Domain.Enums
{
    public sealed class ChatRole : EnumerationBase
    {
        public static readonly ChatRole Owner = new(1, "Owner");
        public static readonly ChatRole Member = new(2, "Member");

        private ChatRole(int id, string name) : base(id, name) { }
    }
}

using VideoConference.Domain.Primitives;

namespace VideoConference.Domain.Enums
{
    public sealed class ChannelRole : EnumerationBase
    {
        public static readonly ChannelRole Owner = new(1, "Owner");
        public static readonly ChannelRole Moderator = new(2, "Moderator");
        public static readonly ChannelRole Member = new(3, "Member");

        private ChannelRole(int id, string name) : base(id, name) { }
    }
}

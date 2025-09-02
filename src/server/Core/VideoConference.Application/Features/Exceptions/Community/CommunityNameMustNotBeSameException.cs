
using VideoConference.Application.Bases;

namespace VideoConference.Application.Features.Exceptions.Community
{
    public class CommunityNameMustNotBeSameException : BaseException
    {
        public CommunityNameMustNotBeSameException() : base("Bu topluluk adı zaten var") { }

    }
}

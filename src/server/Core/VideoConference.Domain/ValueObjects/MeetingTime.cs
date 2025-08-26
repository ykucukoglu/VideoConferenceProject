using VideoConference.Domain.Primitives;

namespace VideoConference.Domain.ValueObjects
{
    public sealed class MeetingTime : ValueObject
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        private MeetingTime(DateTime start, DateTime end)
        {
            if (end <= start) throw new ArgumentException("End must be after start");
            Start = start;
            End = end;
        }

        public static MeetingTime Create(DateTime start, DateTime end) => new(start, end);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Start;
            yield return End;
        }
    }
}

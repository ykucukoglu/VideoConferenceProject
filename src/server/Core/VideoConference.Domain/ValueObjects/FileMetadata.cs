using VideoConference.Domain.Primitives;

namespace VideoConference.Domain.ValueObjects
{
    public sealed class FileMetadata : ValueObject
    {
        public string FileName { get; }
        public string ContentType { get; }
        public long Size { get; }

        private FileMetadata(string fileName, string contentType, long size)
        {
            FileName = fileName;
            ContentType = contentType;
            Size = size;
        }

        public static FileMetadata Create(string fileName, string contentType, long size) =>
            new(fileName, contentType, size);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FileName;
            yield return ContentType;
            yield return Size;
        }
    }
}

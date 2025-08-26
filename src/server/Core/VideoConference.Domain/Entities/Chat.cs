using VideoConference.Domain.Primitives;

namespace VideoConference.Domain.Entities
{
    public class Chat : BaseEntity
    {
        public string Name { get; private set; }
        public ICollection<ChatMember> Members { get; private set; } = new List<ChatMember>();
        public ICollection<ChatMessage> Messages { get; private set; } = new List<ChatMessage>();

        protected Chat() { }

        private Chat(string name) => Name = name;

        public static Chat Create(string name) => new Chat(name);
        public void AddMember(Guid userId) => Members.Add(new ChatMember(Id, userId));
    }
}


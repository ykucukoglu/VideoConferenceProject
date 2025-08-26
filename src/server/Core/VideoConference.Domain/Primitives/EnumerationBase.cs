using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Domain.Primitives
{
    public abstract class EnumerationBase : IEnumeration, IComparable
    {
        public int Id { get; }
        public string Name { get; }

        protected EnumerationBase(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => Name;

        public override bool Equals(object obj) =>
            obj is EnumerationBase other &&
            GetType() == obj.GetType() &&
            Id == other.Id;

        public override int GetHashCode() => Id.GetHashCode();

        public int CompareTo(object other) =>
            Id.CompareTo(((EnumerationBase)other).Id);

        public static IEnumerable<T> GetAll<T>() where T : EnumerationBase =>
            typeof(T).GetFields(System.Reflection.BindingFlags.Public |
                                System.Reflection.BindingFlags.Static |
                                System.Reflection.BindingFlags.DeclaredOnly)
                     .Select(f => f.GetValue(null))
                     .Cast<T>();
    }
}

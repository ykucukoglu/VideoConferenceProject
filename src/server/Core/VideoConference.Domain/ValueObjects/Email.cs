using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Domain.Primitives;

namespace VideoConference.Domain.ValueObjects
{
    public sealed class Email : ValueObject
    {
        public string Address { get; }

        private Email(string address)
        {
            if (string.IsNullOrWhiteSpace(address) || !address.Contains("@"))
                throw new ArgumentException("Invalid email");
            Address = address;
        }

        public static Email Create(string address) => new(address);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Address.ToLowerInvariant();
        }
    }
}

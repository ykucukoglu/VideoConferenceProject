using System;
using System.Collections.Generic;
using System.Linq;

namespace VideoConference.Domain.Primitives
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; protected set; } = DateTime.UtcNow;
        public bool IsDeleted { get; protected set; }

        protected BaseEntity() { }

        public void Delete() => IsDeleted = true;
    }
}

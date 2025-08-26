using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Repositories;
using VideoConference.Domain.Primitives;

namespace VideoConference.Application.Repositories.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, IBaseEntity;
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IBaseEntity;
        Task<int> SaveAsync();
        int Save();
    }
}

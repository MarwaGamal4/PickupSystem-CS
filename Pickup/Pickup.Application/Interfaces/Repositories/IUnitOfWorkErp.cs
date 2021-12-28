using Pickup.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pickup.Application.Interfaces.Repositories
{
    public interface IUnitOfWorkErp : IDisposable
    {
        IRepositoryAsync<T> Repository<T>() where T : class , IEntity;

        Task<int> Commit(CancellationToken cancellationToken);

        Task<int> ComitAndRemoveCache(CancellationToken cancellationToken, string cacheKey);

        Task Rollback();
    }
}

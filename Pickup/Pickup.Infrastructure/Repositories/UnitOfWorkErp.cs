using LazyCache;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Interfaces.Services;
using Pickup.Domain.Contracts;
using Pickup.Domain.Entities;
using Pickup.Infrastructure.Contexts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pickup.Infrastructure.Repositories
{
    public class UnitOfWorkErp : IUnitOfWorkErp
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly ERBSYSTEMContext _dbContext;
        private bool disposed;
        private Hashtable _repositories;
        private readonly IAppCache _cache;

        public UnitOfWorkErp(ICurrentUserService currentUserService, ERBSYSTEMContext dbContext, bool disposed, Hashtable repositories, IAppCache cache)
        {
            _currentUserService = currentUserService;
            _dbContext = dbContext;
            this.disposed = disposed;
            _repositories = repositories;
            _cache = cache;
        }

        public async Task<int> ComitAndRemoveCache(CancellationToken cancellationToken, string cacheKey)
        {
            var result = await _dbContext.SaveChangesAsync(cancellationToken);
            _cache.Remove(cacheKey);
            return result;
        }

        public async Task<int> Commit(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                    _dbContext.Dispose();
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task Rollback()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            return Task.CompletedTask;
        }

        public IRepositoryAsync<TEntity> Repository<TEntity>() where TEntity : class,IEntity
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryAsync<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dbContext);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepositoryAsync<TEntity>)_repositories[type];
        }
    }
}

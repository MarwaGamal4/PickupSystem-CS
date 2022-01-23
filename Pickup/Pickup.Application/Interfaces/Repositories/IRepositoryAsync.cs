using Microsoft.EntityFrameworkCore;
using Pickup.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pickup.Application.Interfaces.Repositories
{
    public interface IRepositoryAsync<T> where T : class, IEntity
    {
        IQueryable<T> Entities { get; }

        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        Task<List<T>> GetPagedReponseAsync(int pageNumber, int pageSize);

        Task<T> AddAsync(T entity);
        Task<List<T>> AddRangeAsync(List<T> entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
        Task<T> GetInclude(int id, Expression<Func<T, object>> include);
        Task<int> ExecuteQry(string Query);
    }
}
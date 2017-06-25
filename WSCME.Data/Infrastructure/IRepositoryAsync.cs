using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WSCME.Data.Infrastructure
{
    public interface IRepositoryAsync<T> where T :class
    {
        Task AddAsync(T entity);
        Task<T> GetByIdAsync(long Id);
        Task<T> GetByIdAsync(string Id);
        Task<T> GetByIdAsync(Guid Id);
        Task<T> GetAsync(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where);
    }
}

using Ordering.Core.Common;
using System.Linq.Expressions;

namespace Ordering.Core.Repositories
{
    public interface IAsyncRepository<T> where T : EntityBase
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}

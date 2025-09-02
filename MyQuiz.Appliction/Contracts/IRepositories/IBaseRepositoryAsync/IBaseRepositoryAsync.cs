using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Appliction.Contracts.IRepositories.IBaseRepositoryAsync
{
    public interface IBaseRepositoryAsync<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? criteria = null);
        Task<List<T>> GetPagedWithFilterAsync(Expression<Func<T, bool>> criteria, int pageIndex, int pageSize);
        Task<int> GetCountWithFilterAsync(Expression<Func<T, bool>> criteria);
        Task<T> GetByIdAsync(int Id);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        Task<bool> IsExistsAsync(Expression<Func<T, bool>> criteria);

        Task<T> AddObjAsync(T Obj);
        Task<T> UpdateAsync(T entity);
        Task<T> RemoveObjAsync(T Obj);
    }
}

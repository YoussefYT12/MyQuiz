using Microsoft.EntityFrameworkCore;
using MyQuiz.Appliction.Contracts.IRepositories.IBaseRepositoryAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Infrastructure.Repositories.BaseRepositoryAsync
{
    public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T> where T : class 
    {
        DbContext db;
        public BaseRepositoryAsync(DbContext _db)
        {
            db = _db;
        }

        public async Task<T> AddObjAsync(T Obj)
        {
            await db.Set<T>().AddAsync(Obj);
            await db.SaveChangesAsync();
            return Obj;
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = db.Set<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }


            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            var data = await db.Set<T>().AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? criteria = null)
        {
            IQueryable<T> query = db.Set<T>();

            if (criteria != null)
            {
                query = query.Where(criteria);
            }


            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            var data = await db.Set<T>().FindAsync(Id);
            return data;
        }

        public async Task<int> GetCountWithFilterAsync(Expression<Func<T, bool>> criteria)
        {
            IQueryable<T> query = db.Set<T>();

            if (criteria != null)
            {
                query = query.Where(criteria);
            }


            int count = await query.AsNoTracking().CountAsync();
            return count;
        }

        public async Task<List<T>> GetPagedWithFilterAsync(Expression<Func<T, bool>> criteria, int pageIndex, int pageSize)
        {
            IQueryable<T> query = db.Set<T>();
            int SkipCount = (pageIndex - 1) * pageSize;
            if (criteria != null)
            {
                query = query.Where(criteria).Skip(SkipCount).Take(pageSize);
            }
            else
            {
                query = query.Skip(SkipCount).Take(pageSize);
            }


            return await query.AsNoTracking().ToListAsync();

        }

        public async Task<bool> IsExistsAsync(Expression<Func<T, bool>> criteria)
        {
            IQueryable<T> query = db.Set<T>();
            bool isExist = false;
            if (criteria != null)
            {
                isExist = await query.AnyAsync(criteria);
            }

            return isExist;
        }

        public async Task<T> RemoveObjAsync(T Obj)
        {
            db.Set<T>().Remove(Obj);
            await db.SaveChangesAsync();
            return Obj;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var result = db.Set<T>().Update(entity);
            await db.SaveChangesAsync();
            return result.Entity;
        }
    }
}

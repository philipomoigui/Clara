using Clara.DataAccess;
using Clara.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Clara.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public RepositoryBase(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void Create(T entity)
        {
            _applicationDbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _applicationDbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return _applicationDbContext.Set<T>()
                .AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _applicationDbContext.Set<T>()
                .Where(expression)
                .AsNoTracking();
        }

        public void Update(T entity)
        {
            _applicationDbContext.Set<T>().Update(entity);
        }
    }
}

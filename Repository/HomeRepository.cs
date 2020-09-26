using Clara.DataAccess;
using Clara.Models;
using Clara.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository
{
    public class HomeRepository : RepositoryBase<Service>, IHomeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public HomeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IQueryable<Service> GetPopularCategory(int categoryId)
        {
           return _applicationDbContext.Services
                .AsNoTracking()
                .Where(c => c.CategoryId == categoryId)
                .OrderBy(s => Guid.NewGuid())
                .Take(6);
        }
    }
}

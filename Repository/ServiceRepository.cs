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
    public class ServiceRepository : RepositoryBase<Service>, IServicesRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        

        public ServiceRepository(ApplicationDbContext applicationDbContext) :base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void CreateService(Service service)
        {
            Create(service);
        }

        public void DeleteService(Service service)
        {
            Delete(service);
        }

        public IEnumerable<Service> GetAllService() =>  FindAll()
            .Include(s => s.Category)
            .Include(s => s.User)
            .ThenInclude(s => s.UserProfile)
            .ToList();

        public IEnumerable<Service> GetServicesByLocationAndSearch(string category, string location, string search)
        {
            return FindByCondition(s => s.Category.CategoryName.Equals(category) && (s.City.Equals(location) || s.State.Equals(location)) && s.BusinessName.Contains(search))
                .Include(s => s.Category)
                .Include(s => s.User)
                .ToList();
            
        }

        public async Task<Service> GetServiceById(Guid serviceId)
        {
            return await FindByCondition(s => s.ServiceId.Equals(serviceId))
                .Include(s => s.Category)
                .Include(s => s.User)
                .ThenInclude(s => s.UserProfile)
                .FirstOrDefaultAsync();
        }

        public void UpdateService(Service service)
        {
            _applicationDbContext.Services.Update(service);
        }

        public IEnumerable<Service> GetServicesByLocation(string category, string location)
        {
            return FindByCondition(s => s.Category.CategoryName.Equals(category) && (s.City.Equals(location) || s.State.Equals(location)))
                .Include(s => s.Category)
                .Include(s => s.User)
                .ThenInclude(s => s.UserProfile)
                .ToList();
        }

        public IEnumerable<Service> GetServicesByCategory(string category)
        {
            return FindByCondition(s => s.Category.CategoryName.Equals(category))
             .Include(s => s.Category)
            .Include(s => s.User)
            .ThenInclude(s => s.UserProfile)
            .ToList();
        }

        public IEnumerable<Service> GetUSerServices(string userId)
        {
            return FindByCondition(u => u.UserId == userId)
             .Include(s => s.Category)
            .Include(s => s.User)
            .ThenInclude(s => s.UserProfile)
            .OrderBy(s => s.BusinessName)
            .ToList();
        }

        public IEnumerable<Service> GetPopularCategory(int categoryId)
        {
            return FindByCondition(s => s.CategoryId.Equals(categoryId))
                 .Include(s => s.Category)
            .Include(s => s.User)
            .ThenInclude(s => s.UserProfile)
  
                 .OrderBy(s => Guid.NewGuid())
                 .Take(6)
                 .ToList();
        }

        public IEnumerable<Service> GetSearchResult(string search)
        {
            return FindByCondition(s => s.BusinessName.Contains(search)).ToList();
        }
    }
}

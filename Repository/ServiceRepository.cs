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
            .ToList();

        public IEnumerable<Service> GetServicesByLocationAndSearch(string category, string location, string search)
        {
            return FindByCondition(s => s.Category.CategoryName.Equals(category) && (s.City.Equals(location) || s.State.Equals(location)) && s.BusinessName.Contains(search));
            
        }

        public async Task<Service> GetServiceById(Guid serviceId)
        {
            return await FindByCondition(s => s.ServiceId.Equals(serviceId))
                .Include(s => s.Category)
                .FirstOrDefaultAsync();
        }

        public void UpdateService(Service service)
        {
            _applicationDbContext.Services.Update(service);
        }

        public IEnumerable<Service> GetServicesByLocation(string category, string location)
        {
           return FindByCondition(s => s.Category.CategoryName.Equals(category) && (s.City.Equals(location) || s.State.Equals(location)))
                .Include(s => s.Category);
        }

        public IEnumerable<Service> GetServicesByCategory(string category)
        {
            return FindByCondition(s => s.Category.CategoryName.Equals(category));
        }
    }
}

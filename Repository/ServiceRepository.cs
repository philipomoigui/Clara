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
    public class ServiceRepository : IServicesRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        

        public ServiceRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task CreateServiceAsync(Service service)
        {
            await _applicationDbContext.Services.AddAsync(service);
        }

        public void DeleteService(Guid id)
        {
            var service = GetServiceById(id);
            _applicationDbContext.Services.Remove(service);
        }

        public IQueryable<Service> GetAllService() => _applicationDbContext.Services
            .AsNoTracking()
            .Include(s => s.Category);
        

        public Service GetServiceById(Guid id)
        {
           return  _applicationDbContext.Services.Where(s => s.ServiceId == id).FirstOrDefault();
        }

        public async Task<bool> SaveAsync()
        {
            return (await _applicationDbContext.SaveChangesAsync() >= 0);
        }

        public void UpdateService(Service service)
        {
            var updateService = GetServiceById(service.ServiceId);
            _applicationDbContext.Services.Update(updateService);
        }
    }
}

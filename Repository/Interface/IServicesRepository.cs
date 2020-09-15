using Clara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository.Interface
{
    public interface IServicesRepository
    {
        IQueryable<Service> GetAllService();
        Service GetServiceById(Guid id);
        Task CreateServiceAsync(Service service);
        void UpdateService(Service service);
        void DeleteService(Guid id);
        Task<bool> SaveAsync();
    }
}

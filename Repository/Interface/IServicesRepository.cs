using Clara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository.Interface
{
    public interface IServicesRepository
    {
        IEnumerable<Service> GetAllService();
        Service GetServiceById(int id);
        Task CreateServiceAsync(Service service);
        void UpdateService(Service service);
        void DeleteService(int id);
        Task<bool> SaveAsync();
    }
}

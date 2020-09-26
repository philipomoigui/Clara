using Clara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository.Interface
{
    public interface IServicesRepository: IRepositoryBase<Service>
    {
        IEnumerable<Service> GetAllService();
        Task<Service> GetServiceById(Guid serviceId);
        void CreateService(Service service);
        void UpdateService(Service service);
        void DeleteService(Service service);
        public IEnumerable<Service> GetServicesByCategory(string category);
        public IEnumerable<Service> GetServicesByLocation(string category, string location);
        public IEnumerable<Service> GetServicesByLocationAndSearch(string category, string location, string search);
    }
}
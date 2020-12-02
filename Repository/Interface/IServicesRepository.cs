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
        IEnumerable<Service> GetRandomService(Guid serviceId);
        IEnumerable<Service> GetPopularCategory(int categoryId);
        public IEnumerable<Service> GetUSerServices(string userId);
        public IEnumerable<Service> GetSearchResult(string search);
        public IEnumerable<Service> GetServicesBySearch(string search);
        public IEnumerable<Service> GetServicesByCategory(string category);
        public IEnumerable<Service> GetServicesByLocation(string location);
        public IEnumerable<Service> GetServicesByLocation(string category, string location);
        public IEnumerable<Service> GetServicesByLocationAndSearch(string category, string location, string search);
    }
}
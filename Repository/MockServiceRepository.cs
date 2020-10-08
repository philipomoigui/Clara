using Clara.Models;
using Clara.Models.Enums;
using Clara.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Clara.Repository
{
    public class MockServiceRepository : IServicesRepository
    {
        private List<Service> _serviceList;

        public MockServiceRepository()
        {
            _serviceList = new List<Service>()
            {
                new Service(){
                    
                },
                new Service(){
                    
                }
            };
        }

        public void Create(Service entity)
        {
            throw new NotImplementedException();
        }

        public void CreateService(Service service)
        {
            throw new NotImplementedException();
        }

        public Task CreateServiceAsync(Service service)
        {
            throw new NotImplementedException();
        }

        public void Delete(Service entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteService(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteService(Guid id)
        {
            throw new NotImplementedException();
        }

        public void DeleteService(Service service)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Service> FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Service> FindByCondition(Expression<Func<Service, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Service> GetAllService()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Service> GetPopularCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Service> GetSearchResult(string search)
        {
            throw new NotImplementedException();
        }

        public Service GetServiceById(int id)
        {
            throw new NotImplementedException();
        }

        public Service GetServiceById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Service> GetServicesByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Service> GetServicesByLocation(string category, string location)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Service> GetServicesByLocation(string location)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Service> GetServicesByLocationAndSearch(string category, string location, string search)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Service> GetUSerServices(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Service entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateService(Service service)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Service> IServicesRepository.GetAllService()
        {
            throw new NotImplementedException();
        }

        Task<Service> IServicesRepository.GetServiceById(Guid serviceId)
        {
            throw new NotImplementedException();
        }
    }
}

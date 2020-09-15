using Clara.Models;
using Clara.Models.Enums;
using Clara.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task CreateServiceAsync(Service service)
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

        public IQueryable<Service> GetAllService()
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

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateService(Service service)
        {
            throw new NotImplementedException();
        }
    }
}

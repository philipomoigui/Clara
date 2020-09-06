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
                    ServiceId = 1,
                    ServiceName = "Jane Bacch",
                    ServiceType = ServiceProviders.EventPlanners,
                    AddOns = new List<string>{"Free Event Advisory", "Always on Call"},
                    Email = "Jane@events.com",
                    PhoneNumber = "09012919871",
                    AddressLine = "21, jarred Avenue",
                    City = "Surulere",
                    Price = 98900,
                    State = "Lagos"
                },
                new Service(){
                    ServiceId = 2,
                    ServiceName = "The coque Dance group",
                    ServiceType = ServiceProviders.EntertainmentAgency,
                    AddOns = new List<string>{"Free Highlife Band", "Decentralised bands"},
                    Email = "Jane@events.com",
                    PhoneNumber = "0816998191",
                    AddressLine = "15, Otta way",
                    City = "Danfa",
                    Price = 70000,
                    State = "Ogun"
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

        public IEnumerable<Service> GetAllService()
        {
            throw new NotImplementedException();
        }

        public Service GetServiceById(int id)
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

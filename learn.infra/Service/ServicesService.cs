using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class ServicesService : IServicesService
    {
        private readonly IServicesRepository servicesRepository;

        public ServicesService(IServicesRepository servicesRepository)
        {
            this.servicesRepository = servicesRepository;
        }

        public void AddServices(Services services)
        {
            servicesRepository.AddServices(services);
        }

        public void DeleteServices(int id)
        {
            servicesRepository.DeleteServices(id);
        }

        public IList<Services> GetAllServices()
        {
            return servicesRepository.GetAllServices();
        }

        public Services GetServiceById(int id)
        {
            return servicesRepository.GetServiceById(id);
        }

        public void UpDateServices(Services services)
        {
            servicesRepository.UpDateServices(services);
        }
        public Services getByServicesName(string names)
        {
            return servicesRepository.getByServicesName(names);
        }
    }
}

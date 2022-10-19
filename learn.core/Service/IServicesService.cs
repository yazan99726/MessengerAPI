using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
    public interface IServicesService
    {
        //public T CrudServices<T>(Services services, string httpMethod);

        public IList<Services> GetAllServices();
        public void AddServices(Services services);
        public void DeleteServices(int id);
        public void UpDateServices(Services services);
        public Services GetServiceById(int id);
        public Services getByServicesName(string names);
    }
}

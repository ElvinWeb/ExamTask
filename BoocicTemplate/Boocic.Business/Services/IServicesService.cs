using Boocic.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boocic.Business.Services
{
    public interface IServicesService
    {
        Task CreateAsync(Service service);
        Task DeleteAsync(int id);
        Task SoftDelete(int id);
        Task UpdateAsync(Service service);
        Task<List<Service>> GetAllServiceAsync();
        Task<Service> GetServiceAsync(int id);
      
    }
}

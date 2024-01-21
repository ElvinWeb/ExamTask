using Boocic.Core.Repositories;
using Boocic.Data.Repositories.Implemetations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boocic.Data
{
    public static class RepositoryRegistration
    {
        public static  void RepositoriesRegister(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IServiceRepository, ServiceRepository>();
            serviceDescriptors.AddScoped<ISettingRepository, SettingRepository>();

        }
    }
}

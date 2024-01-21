using Boocic.Business.Services;
using Boocic.Business.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boocic.Business
{
    public static class ServiceRegistration
    {
        public static void ServicesRegister(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IAccountService, AccountService>();
            serviceDescriptors.AddScoped<IServicesService, ServicesService>();
            serviceDescriptors.AddScoped<ISettingService, SettingService>();
        }
    }
}

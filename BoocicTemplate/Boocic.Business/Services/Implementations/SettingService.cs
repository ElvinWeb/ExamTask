using Boocic.Core.Entites;
using Boocic.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boocic.Business.Services.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public Task<List<Setting>> GetAllServiceAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Setting> GetServiceAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Setting setting)
        {
            throw new NotImplementedException();
        }
    }
}

using Boocic.Business.CustomExceptions.Common;
using Boocic.Core.Entites;
using Boocic.Core.Repositories;
using Boocic.Data.Repositories.Implemetations;
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

        public Task<List<Setting>> GetAllSettingAsync()
        {
            return _settingRepository.GetAllAsync(x => !x.IsDeleted);
        }

        public Task<Setting> GetSettingAsync(int id)
        {
            if (id == null || id <= 0) throw new InvalidIdOrBlowThanZeroException();

            return _settingRepository.GetByIdAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task UpdateAsync(Setting setting)
        {
            Setting wantedSetting = await _settingRepository.GetByIdAsync(x => x.Id == setting.Id && !x.IsDeleted);
            if (wantedSetting == null) throw new InvalidEntityException();

            wantedSetting.Value = setting.Value;
            wantedSetting.UpdatedDate = DateTime.UtcNow.AddHours(4);

            await _settingRepository.SaveAsync();
        }
    }
}

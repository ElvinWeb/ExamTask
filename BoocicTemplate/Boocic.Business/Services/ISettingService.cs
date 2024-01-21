using Boocic.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boocic.Business.Services
{
    public interface ISettingService
    {
        Task UpdateAsync(Setting setting);
        Task<List<Setting>> GetAllSettingAsync();
        Task<Setting> GetSettingAsync(int id);
    }
}

using Boocic.Business.Services;
using Boocic.Core.Entites;

namespace Boocic.UI.ViewService
{
    public class LayoutService
    {
        private readonly ISettingService _settingService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LayoutService(ISettingService settingService, IHttpContextAccessor httpContextAccessor)
        {
            _settingService = settingService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Setting>> GetSettings()
        {
            var settings = await _settingService.GetAllSettingAsync();

            return settings;
        }
    }
}

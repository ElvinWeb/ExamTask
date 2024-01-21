using Boocic.Business.Services;
using Boocic.Core.Entites;
using Microsoft.AspNetCore.Identity;

namespace Boocic.UI.ViewService
{
    public class LayoutService
    {
        private readonly ISettingService _settingService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public LayoutService(ISettingService settingService, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _settingService = settingService;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<List<Setting>> GetSettings()
        {
            var settings = await _settingService.GetAllSettingAsync();

            return settings;
        }

        public async Task<User> GetAdmin()
        {
            User admin = null;
            string name = _httpContextAccessor.HttpContext.User.Identity.Name;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                admin = await _userManager.FindByNameAsync(name);
            }

            return admin;
        }
    }
}

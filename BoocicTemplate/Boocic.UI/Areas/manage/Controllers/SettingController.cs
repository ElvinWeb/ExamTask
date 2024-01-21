using Boocic.Business.CustomExceptions.Common;
using Boocic.Business.Services;
using Boocic.Core.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Boocic.UI.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public async Task<IActionResult> Index()
        {
            List<Setting> settings = await _settingService.GetAllSettingAsync();

            return View(settings);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Setting setting = null;

            try
            {
                setting = await _settingService.GetSettingAsync(id);
            }
            catch (InvalidIdOrBlowThanZeroException ex)
            {
                return View("error");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "unexpected error is occur!");
                return View();
            }

            if (setting == null) return View();

            return View(setting);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Setting setting)
        {
            try
            {
                await _settingService.UpdateAsync(setting);
            }
            catch (InvalidEntityException ex)
            {
                return View("error");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "unexpected error is occur!");
                return View();
            }

            return RedirectToAction("index", "setting");
        }
    }
}

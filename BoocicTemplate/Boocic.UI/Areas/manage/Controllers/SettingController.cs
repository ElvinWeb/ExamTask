using Boocic.Core.Entites;
using Microsoft.AspNetCore.Mvc;

namespace Boocic.UI.Areas.manage.Controllers
{
    [Area("manage")]
    public class SettingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Setting setting)
        {
            return View();
        }
    }
}

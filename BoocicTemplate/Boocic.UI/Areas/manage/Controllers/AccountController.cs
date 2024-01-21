using Microsoft.AspNetCore.Mvc;

namespace Boocic.UI.Areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

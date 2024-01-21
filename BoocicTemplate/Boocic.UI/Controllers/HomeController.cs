using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Boocic.UI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
                
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
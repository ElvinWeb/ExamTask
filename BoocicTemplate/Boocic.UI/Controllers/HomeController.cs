using Boocic.Business.Services;
using Boocic.Core.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Boocic.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicesService _servicesService;

        public HomeController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }
        public async Task<IActionResult> Index()
        {
            List<Service>  services = await _servicesService.GetAllServiceAsync();

            return View(services);
        }
    }
}
using Boocic.Business.CustomExceptions.Common;
using Boocic.Business.CustomExceptions.ServiceImage;
using Boocic.Business.Services;
using Boocic.Core.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boocic.UI.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin")]
    public class ServiceController : Controller
    {
        private readonly IServicesService _servicesService;

        public ServiceController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }
        public async Task<IActionResult> Index()
        {
            List<Service> services = await _servicesService.GetAllServiceAsync();
            return View(services);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Service service)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                await _servicesService.CreateAsync(service);
            }
            catch (InvalidImageContentTypeOrSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (ImageRequiredException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "unexpected error is occur!");
                return View();
            }

            return RedirectToAction("index", "service");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Service service = null;

            try
            {
                service = await _servicesService.GetServiceAsync(id);
            }
            catch (InvalidIdOrBlowThanZeroException ex)
            {
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "unexpected error is occur!");
                return View();
            }

            return View(service);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Service service)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                await _servicesService.UpdateAsync(service);
            }
            catch (InvalidEntityException ex)
            {
                return View();
            }
            catch (InvalidImageContentTypeOrSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "unexpected error is occur!");
                return View();
            }

            return RedirectToAction("index", "service");
        }
        [HttpGet]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _servicesService.SoftDelete(id);
            }
            catch (InvalidIdOrBlowThanZeroException ex)
            {
                return View();
            }
            catch (InvalidEntityException ex)
            {
                return View();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "unexpected error is occur!");
                return View();
            }

            return RedirectToAction("index", "service");


        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _servicesService.DeleteAsync(id);
            }
            catch (InvalidIdOrBlowThanZeroException ex)
            {
                return View();
            }
            catch (InvalidEntityException ex)
            {
                return View();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "unexpected error is occur!");
                return View();
            }


            return Ok();
        }

    }
}

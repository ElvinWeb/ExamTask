﻿using Boocic.Core.Entites;
using Microsoft.AspNetCore.Mvc;

namespace Boocic.UI.Areas.manage.Controllers
{
    [Area("manage")]
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Service service)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Service service)
        {
            return View();
        }
        [HttpGet]
        public IActionResult SoftDelete(int id)
        {
            return View();


        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View();
        }

    }
}
using FitForLife.Models;
using FitForLife.Services.Data.Classes;
using FitForLife.Web.ViewModels.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FitForLife.Controllers
{
    public class HomeController : Controller
        
    {
        private readonly IClassesService classesService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IClassesService classesService)
        {
            _logger = logger;
            this.classesService = classesService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new AllClassesViewModel
            {
                Classes = await this.classesService.GetAllAsync<ClassViewModel>()
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

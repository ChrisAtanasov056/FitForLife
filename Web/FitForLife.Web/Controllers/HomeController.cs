using FitForLife.Models;
using FitForLife.Services.Data.Cards;
using FitForLife.Services.Data.Classes;
using FitForLife.Web.ViewModels.Cards;
using FitForLife.Web.ViewModels.Classes;
using FitForLife.Web.ViewModels.Home;
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
        private readonly ICardsService cardsService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IClassesService classesService, ICardsService cardsService)
        {
            _logger = logger;
            this.classesService = classesService;
            this.cardsService = cardsService;
        }

        public async Task<IActionResult> Index()
        {
            var classViewModel = new HomeAllClassViewModel
            {
                Classes = await this.classesService.GetAllAsync<HomeClassViewModel>()
            };
            var cardsViewModel = new AllCardsViewModel
            {
                Cards = await this.cardsService.GetAllAsync<CardsViewModel>()
            };
            var allView = new HomeViewModels
            {
                Cards = cardsViewModel,
                Classes = classViewModel,
            };
            return View(allView);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("/Home/Error/404")]
        public IActionResult Error404()
        {
            return this.View();
        }

        [Route("/Home/Error/{code:int}")]
        public IActionResult Error(int code)
        {
            // Could handle different codes here
            // or just return the default error view
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}

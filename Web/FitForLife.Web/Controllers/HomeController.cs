namespace FitForLife.Controllers
{
    using FitForLife.Models;
    using FitForLife.Services.Data.Cards;
    using FitForLife.Services.Data.Classes;
    using FitForLife.Services.Data.Trainers;
    using FitForLife.Web.ViewModels.Cards;
    using FitForLife.Web.ViewModels.Classes;
    using FitForLife.Web.ViewModels.Home;
    using FitForLife.Web.ViewModels.Trainers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using static FitForLife.Common.GlobalConstants.Cache;

    public class HomeController : Controller

    {
        private readonly IClassesService classesService;
        private readonly ITrainersService trainersService;
        private readonly ICardsService cardsService;
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache cache;

        public HomeController(ILogger<HomeController> logger, IClassesService classesService, ICardsService cardsService, IMemoryCache cache, ITrainersService trainersService)
        {
            _logger = logger;
            this.classesService = classesService;
            this.cardsService = cardsService;
            this.cache = cache;
            this.trainersService = trainersService;
        }

        public async Task<IActionResult> Index()
        {
            var allView = this.cache.Get<HomeViewModels>(HomeViewMemoryCache);
            if (allView == null)
            {
                var classViewModel = new HomeAllClassViewModel
                {
                    Classes = await this.classesService.GetAllAsync<HomeClassViewModel>(3)
                };
                var cardsViewModel = new AllCardsViewModel
                {
                    Cards = await this.cardsService.GetAllAsync<CardsViewModel>()
                };
                var trainerViewModel = new AllTrainersViewModel
                {
                    Trainers = await this.trainersService.GetAllTrainersAsync<TrainerViewModel>(3)
                };
                allView = new HomeViewModels
                {
                    Cards = cardsViewModel,
                    Classes = classViewModel,
                    Trainers = trainerViewModel,
                };
                var cacheOptions = new MemoryCacheEntryOptions()
                     .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

                this.cache.Set(HomeViewMemoryCache, allView, cacheOptions);
            }
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

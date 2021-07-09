﻿namespace FitForLife.Controllers
{
    using FitForLife.Data;
    using FitForLife.Services.Data.Classes;
    using FitForLife.Web.ViewModels.Classes;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ClassesController : Controller
    {
        private readonly IClassesService classesService;
        private readonly FitForLifeDbContext dbContext;

        public ClassesController(IClassesService classesService, FitForLifeDbContext dbContext)
        {
            this.classesService = classesService;
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var classes = dbContext
                .Classes
                .Select(c => new ClassViewModel
                {
                    Name = c.Name,
                    Description = c.Description,
                    PictureUrl = c.PictureUrl,
                }).ToList();
            var viewModel = new AllClassesViewModel();
            foreach (var item in classes)
            {
                viewModel.Classes.Add(item);
            }
            ViewBag.AllClasses = viewModel.Classes;
            //var viewModel = new AllClassesViewModel
            //{
            //    Classes = await this.classesService.GetAllAsync<ClassViewModel>()
            //};
            return this.View();
        }
    }
}

using FitForLife.Data.Models;
using FitForLife.Services.Data.Classes;
using FitForLife.Services.Data.Trainers;
using FitForLife.Services.Data.Users;
using FitForLife.Web.ViewModels.Classes;
using FitForLife.Web.ViewModels.Trainers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitForLife.Areas.Administration.Controllers
{
    public class TrainersController : AdministrationController
    {
        private readonly ITrainersService trainersService;
        private readonly IClassesService classesService;

        public TrainersController(ITrainersService trainersService, IClassesService classesService)
        {
            this.trainersService = trainersService;
            this.classesService = classesService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new AllTrainersViewModel
            {
                Trainers = await this.trainersService.GetAllTrainersAsync<TrainerViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult AddTrainer()
        {
            var viewModels = classesService.GetAllAsync<ClassViewModel>().Result.Select(x=>x.Id);
            var viewModelsNames = classesService.GetAllAsync<ClassViewModel>().Result.Select(x => x.Name);
            this.ViewData["Classes"] = new SelectList(viewModels);
            this.ViewData["ClassesNames"] = new SelectList(viewModelsNames);
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTrainer(TrainerInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.trainersService.AddAsync(
                model.FirstName, 
                model.LastName,
                model.ProfilePictureUrl,
                model.Email, 
                model.Password, 
                model.Age ,
                model.City , 
                model.Description,
                model.ClassId);
            return this.RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteTrainer(string Id)
        {
            await this.trainersService.DeleteAsync(Id);

            return this.RedirectToAction("Index");
        }
    }
}

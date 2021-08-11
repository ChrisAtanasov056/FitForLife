namespace FitForLife.Areas.Trainer.Controllers
{
    using FitForLife.Data.Models.Enums;
    using FitForLife.Services.Data.Exercises;
    using FitForLife.Services.Data.Trainers;
    using FitForLife.Services.Data.WorkoutPlan;
    using FitForLife.Web.ViewModels.Users;
    using FitForLife.Web.ViewModels.WorkoutPlan;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class MyClientsController : TrainerController
    {
        private readonly ITrainersService trainersService;
        private readonly IExercisesService exercisesService;
        private readonly IWorkoutPlanService workoutPlanService;

        public MyClientsController(ITrainersService trainersService, IExercisesService exercisesService , IWorkoutPlanService workoutPlanService)
        {
            this.trainersService = trainersService;
            this.exercisesService = exercisesService;
            this.workoutPlanService = workoutPlanService;
        }

        public async Task<IActionResult> Index()
        {
            var trainerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var classViewModel = new AllClientsViewModel
            {
                Clients = await this.trainersService.GetAllClients<UsersViewModel>(trainerId)
            };
            //var classViewModel = this.trainersService.GetAllClients<UsersViewModel>(trainerId);
            //;
            return this.View(classViewModel);
        }
        public async Task<IActionResult> PlanDetails(string planId)
        {
            var viewModel = await this.workoutPlanService.GetWorkoutPlanById<WorkoutPlanViewModel>(planId);
            return this.View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddProgramIndex(string clientId)
        {
            var exercises = await this.exercisesService.GetAllExerciseAsync<ExerciseViewModel>();
            this.ViewData["Exercises"] = new SelectList(exercises, nameof(ExerciseViewModel.Id),nameof(ExerciseViewModel.Name), nameof(ExerciseViewModel.Difficulty));
            this.ViewData["ClientId"] = clientId;
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProgram(AllTrainingDaysInput model)
        {
            await this.workoutPlanService.AddProgramAsync(model);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProgram(string Id)
        {
            await this.workoutPlanService.DeletePlan(Id);
            return RedirectToAction("Index");
        }
    }
}

namespace FitForLife.Controllers
{
    using FitForLife.Services.Data.Trainers;
    using FitForLife.Web.ViewModels.Trainers;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class TrainersController : Controller
    {
        private readonly ITrainersService trainersService;

        public TrainersController(ITrainersService trainersService)
        {
            this.trainersService = trainersService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var viewModel = new AllTrainersViewModel
            {
                Trainers = await this.trainersService.GetAllTrainersAsync<TrainerViewModel>()
            };
            if (viewModel == null)
            {
                return new StatusCodeResult(404);
            }
            return this.View(viewModel);
        }
        public async Task<IActionResult> Details(string Id)
        {
            var trainerView =await this.trainersService.GetTrainerById<TrainerViewModel>(Id);
            
            return this.View(trainerView);
        }
        [HttpPost]
        public async Task<IActionResult> AddUserToTrainer(string trainerId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId==null)
            {
                return Redirect("/Identity/Account/Login");
            }
            await trainersService.AddUserToTrainer(trainerId, userId);
            return RedirectToAction("All");
        }

    }
}

namespace FitForLife.Controllers
{
    using FitForLife.Services.Data.Trainers;
    using FitForLife.Web.ViewModels.Trainers;
    using Microsoft.AspNetCore.Mvc;
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
            return this.View(viewModel);
        }
    }
}

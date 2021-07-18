namespace FitForLife.Controllers
{
    using FitForLife.Services.Data.Classes;
    using FitForLife.Web.ViewModels.Classes;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ClassesController : Controller
    {
        private readonly IClassesService classesService;

        public ClassesController(IClassesService classesService)
        {
            this.classesService = classesService;
            
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new AllClassesViewModel
            {
                Classes = await this.classesService.GetAllAsync<ClassViewModel>()
            };
            return this.View(viewModel);
        }
    }
}

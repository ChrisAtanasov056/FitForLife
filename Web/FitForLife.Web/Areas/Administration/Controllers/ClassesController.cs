namespace FitForLife.Areas.Administration.Controllers
{
    using FitForLife.Services.Data.Classes;
    using FitForLife.Web.ViewModels.Classes;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ClassesController : AdministrationController
    {
        private readonly IClassesService classesService;

        public ClassesController(IClassesService classesService)
        {
            this.classesService = classesService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new AllClassesViewModel
            {
                Classes = await this.classesService.GetAllAsync<ClassViewModel>(),
            };
            return this.View(viewModel);
        }
    }
}

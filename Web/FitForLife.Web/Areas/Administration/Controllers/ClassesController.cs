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

        public IActionResult AddClass()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddClass(ClassInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.classesService.AddAsync(model.Name, model.Description, model.PictureUrl);
            return this.RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteClass(int Id)
        {
            await this.classesService.DeleteAsync(Id);

            return this.RedirectToAction("Index");
        }
    }
}

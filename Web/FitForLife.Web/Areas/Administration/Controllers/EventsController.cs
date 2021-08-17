namespace FitForLife.Areas.Administration.Controllers
{
    using FitForLife.Data.Models;
    using FitForLife.Services.Data.Classes;
    using FitForLife.Services.Data.Events;
    using FitForLife.Web.ViewModels.Classes;
    using FitForLife.Web.ViewModels.Events;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EventsController :AdministrationController
    {
        private readonly IEventService eventService;
        private readonly IClassesService classesService;

        public EventsController(IEventService eventService, IClassesService classesService)
        {
            this.eventService = eventService;
            this.classesService = classesService;
        }
        public async Task<IActionResult> Index()
        {
            var viewModel = new AllEventsViewModel
            {
                Events = await this.eventService.GetAllEventsAsync<EventViewModel>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddEvent()
        {
            var classViews = await this.classesService.GetAllAsync<ClassViewModel>();
            this.ViewData["Events"] = new SelectList(classViews, 
                nameof(ClassViewModel.Id), 
                nameof(ClassViewModel.Name));
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent(EventInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            
            await this.eventService.AddAsync(model.ClassId, model.StartEvent, model.EndEvent, model.AvailableSpots, model.Description);
            return this.RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteEvent(string Id)
        {
            await this.eventService.DeleteAsync(Id);

            return this.RedirectToAction("Index");
        }
    }
}

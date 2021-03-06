
namespace FitForLife.Controllers
{
    using FitForLife.Services.Data.Events;
    using FitForLife.Web.ViewModels;
    using FitForLife.Web.ViewModels.Events;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class AppointmentsController : Controller
    {
        private readonly IEventService eventServices;

        public AppointmentsController(IEventService eventServices)
        {
            this.eventServices = eventServices;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new AllEventsViewModel
            {
                Events = await this.eventServices.GetAllEventsAsync<EventViewModel>()
            };
            if (viewModel == null)
            {
                var error = new ErrorViewModel();
                return this.View(error);
            }
            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(string Id)
        {
            var viewModel = await this.eventServices.GetByIdAsync<EventViewModel>(Id);

            if (this.User.Identity.IsAuthenticated)
            {
                return this.View(viewModel);
            }
            return Redirect("/Identity/Account/Login");

        }
        public async Task<IActionResult> AddUserToEvent(string eventId)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var @event = await eventServices.AddUserToEvent(userId,eventId);
                if (@event == null)
                {
                    return Redirect("/Cards/Index");
                }
                return Redirect("/Identity/Account/Manage/MyCard");
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }

        }
    }
}

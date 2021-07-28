
namespace FitForLife.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AppointmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

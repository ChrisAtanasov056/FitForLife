namespace FitForLife.Areas.Trainer.Controllers
{
    using FitForLife.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.TrainerRoleName)]
    [Area("Trainer")]
    public class TrainerController: Controller
    {

    }
}

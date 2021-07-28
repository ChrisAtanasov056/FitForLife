namespace FitForLife.Controllers
{
    using FitForLife.Data.Models;
    using FitForLife.Services.Data.Cards;
    using FitForLife.Services.Data.Users;
    using FitForLife.Web.ViewModels.Cards;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class CardsController : Controller
    {
        private readonly ICardsService cardsService;
        private readonly IUserService UserService;

        public CardsController(ICardsService cardsService, IUserService userService)
        {
            this.cardsService = cardsService;
            UserService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var cardsViewModel = new AllCardsViewModel
            {
                Cards = await this.cardsService.GetAllAsync<CardsViewModel>()
            };
            return View(cardsViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> BuyCard(int cardId)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                await UserService.AddCardToUser(userId, cardId);
                return Redirect("/Identity/Account/Manage/MyCard");
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
        }
    }
}

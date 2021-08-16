namespace FitForLife.Web.ViewModels.Home
{
    using FitForLife.Web.ViewModels.Cards;
    using FitForLife.Web.ViewModels.Classes;
    using FitForLife.Web.ViewModels.Trainers;

    public class HomeViewModels
    {
        public AllCardsViewModel Cards { get; set; }

        public HomeAllClassViewModel Classes { get; set; }

        public AllTrainersViewModel Trainers { get; set; }
       
    }
}

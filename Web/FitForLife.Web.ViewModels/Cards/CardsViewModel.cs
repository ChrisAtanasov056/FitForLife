namespace FitForLife.Web.ViewModels.Cards
{
    using FitForLife.Data.Models;
    using FitForLife.Services.Mapping;

    public class CardsViewModel : IMapFrom<Card>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Visits { get; set; }
    }
}

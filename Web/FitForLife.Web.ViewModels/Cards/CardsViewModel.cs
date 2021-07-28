namespace FitForLife.Web.ViewModels.Cards
{
    using FitForLife.Data.Models;
    using FitForLife.Services.Mapping;
    using System;
    using System.Collections.Generic;

    public class CardsViewModel : IMapFrom<Card>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Visits { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

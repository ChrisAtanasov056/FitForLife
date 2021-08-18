using FitForLife.Web.ViewModels.Cards;
using FitForLife.Web.ViewModels.Classes;
using FitForLife.Web.ViewModels.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitForLife.Tests.Data
{
    using static Data.Classes;
    using static Data.Users;
    using static Data.Cards;
    class HomeViewModelTest
    {
        public AllCardsViewModel Cards
        {
            get
            {
                return Cards;
            }
            set
            {
                Cards.Cards = ThreeCard;
            }
        }
        public HomeAllClassViewModel Classes { get; set; }

        public AllTrainersViewModel Trainers { get; set; }
    }
}

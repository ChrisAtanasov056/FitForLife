
using FitForLife.Data.Models;
using FitForLife.Web.ViewModels.Cards;
using FitForLife.Web.ViewModels.Classes;
using NLipsum.Core;
using System.Collections.Generic;
using System.Linq;

namespace FitForLife.Tests.Data
{
    public class Cards
    {
        public static List<CardsViewModel> ThreeCard
           => Enumerable.Range(0, 3).Select(i => new CardsViewModel
           {
               Name = new Word().ToString(),
               Price = 30m,
               Visits = 10
           }).ToList();
        
           
        

    }
}

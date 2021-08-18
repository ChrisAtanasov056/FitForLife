namespace FitForLife.Tests.Controllers
{
    using FitForLife.Controllers;
    using FitForLife.Web.ViewModels.Home;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static Data.Classes;
    using static Data.Users;
    using static Data.Cards;
    using FluentAssertions;
    using FitForLife.Web.ViewModels.Classes;
    
    using FitForLife.Web.ViewModels.Cards;
    using FitForLife.Web.ViewModels.Trainers;

    public class HomeControllerTest
    {
        //    [Fact]
        //    public void ErrorRouteShouldBeMapped()
        //        => MyRouting
        //            .Configuration()
        //            .ShouldMap("/Home/Error")
        //            .To<HomeController>(c => c.Error404());
        //    [Fact]
        //    public void IndexRouteShouldBeMapped()
        //        => MyRouting
        //            .Configuration()
        //            .ShouldMap("/")
        //            .To<HomeController>(c => c.Index());
        //    [Fact]
        //    public void IndexShouldReturnViewWithCorrectModelAndData()
        //        => MyMvc
        //           .Pipeline()
        //           .ShouldMap("/")
        //           .To<HomeController>(c => c.Index())
        //           .Which(controller => controller
        //               .WithData(new 
        //               {
        //                   Cards = new AllCardsViewModel
        //                   {
        //                       Cards = ThreeCard
        //                   },
        //                   Classes = new HomeAllClassViewModel
        //                   {
        //                       Classes = ThreeClasses
        //                   },
        //                   Trainers = new AllTrainersViewModel
        //                   {
        //                       Trainers = twoTrainers
        //                   }
        //               }))
        //           .ShouldReturn()
        //           .View(view => view
        //               .WithModelOfType<HomeViewModels>()
        //               .Passing(m => m.Cards.Cards.Should().HaveCount(3)));
        //=> MyController<HomeController>
        //    .Instance(controller => controller
        //        .WithData(new HomeViewModels  
        //        {
        //            Cards = new AllCardsViewModel
        //            {
        //                Cards = ThreeCard
        //            },
        //            Classes = new HomeAllClassViewModel
        //            {
        //                Classes = ThreeClasses
        //            },
        //            Trainers = new AllTrainersViewModel
        //            {
        //                Trainers = twoTrainers
        //            }
        //        }))
        //    .Calling(c => c.Index())
        //    .ShouldHave()
        //    .MemoryCache(cache => cache
        //        .ContainingEntry(entry => entry
        //            .WithKey(HomeViewMemoryCache)
        //            .WithAbsoluteExpirationRelativeToNow(TimeSpan.FromMinutes(15))
        //            .WithValueOfType<HomeViewModels>()))
        //    .AndAlso()
        //    .ShouldReturn()
        //    .View(view => view
        //        .WithModelOfType<HomeViewModels>()
        //        .Passing(model => model.Trainers.Trainers.Should().HaveCount(2)));
    }
}

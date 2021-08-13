namespace FitForLife.Tests.Controllers
{
    using FitForLife.Controllers;
    using FitForLife.Tests.Data;
    using FitForLife.Web.ViewModels.Home;
    using Moq;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static Data.Classes;
    using static Data.Blogs;
    using FluentAssertions;
    using System.Linq;
    using FitForLife.Web.ViewModels.Classes;

    public class HomeControllerTest
    {
        [Fact]
        public void IndexShouldReturnViewWithCorrectModelAndData()
            => MyMvc
                .Pipeline()
                .ShouldMap("/")
                .To<HomeController>(c => c.Index())
                .Which(controller => controller
                    .WithData())
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<HomeViewModels>()
                    .Passing(m => m.Should().NotBeNull()));
    }
}

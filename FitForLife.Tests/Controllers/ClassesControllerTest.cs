
namespace FitForLife.Tests.Controllers
{
    using FitForLife.Controllers;
    using FitForLife.Web.ViewModels.Classes;
    using FluentAssertions;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static Data.Classes;

    public class ClassesControllerTest
    {
        [Fact]
        public void IndexShouldReturnViewWithCorrectModelAndData()
          => MyMvc
              .Pipeline()
              .ShouldMap("/Classes")
              .To<ClassesController>(c => c.Index())
              .Which(controller => controller
                  .WithData(ThreeClasses))
              .ShouldReturn()
              .View(view => view
                  .WithModelOfType<AllClassesViewModel>()
                  .Passing(m => m.Classes.Should().HaveCount(3)));
    }
}

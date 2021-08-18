
namespace FitForLife.Tests.Controllers
{
    using FitForLife.Controllers;
    using FitForLife.Web.ViewModels.Events;
    using FluentAssertions;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static Data.Events;

    public class EventsControllerTest
    {
        [Fact]
        public void IndexShouldReturnViewWithCorrectModelAndData()
          => MyMvc
              .Pipeline()
              .ShouldMap("/Appointments")
              .To<AppointmentsController>(c => c.Index())
              .Which(controller => controller
                  .WithData(FiveEvents))
              .ShouldReturn()
              .View(view => view
                  .WithModelOfType<AllEventsViewModel>()
                  .Passing(m => m.Events.Should().HaveCount(5)));
    }
}

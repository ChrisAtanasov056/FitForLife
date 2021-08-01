namespace FitForLife.Web.ViewModels.Appointment
{
    using FitForLife.Data.Models;
    using FitForLife.Services.Mapping;
    using FitForLife.Web.ViewModels.Events;

    public class AppointmentViewModel: IMapFrom<Appointment>
    {
        public FitForLifeUser User { get; set; }

        public string EventId { get; set; }

        public EventViewModel Event { get; set; }
    }
}

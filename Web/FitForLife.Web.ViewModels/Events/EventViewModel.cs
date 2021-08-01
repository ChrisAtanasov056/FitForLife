namespace FitForLife.Web.ViewModels.Events
{
    using FitForLife.Data.Models;
    using FitForLife.Services.Mapping;
    using System;

    public class EventViewModel : IMapFrom<Event>
    {
        public string Id { get; set; }

        public DateTime StartEvent { get; set; }

        public DateTime EndEvent { get; set; }

        public int AvailableSpots { get; set; }

        public string Description { get; set; }

        public Class Class { get; set; }
    }
}

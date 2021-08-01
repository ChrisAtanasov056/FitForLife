using FitForLife.Data.Models;
using FitForLife.Services.Mapping;
using FitForLife.Web.ViewModels.Classes;
using System;

namespace FitForLife.Web.ViewModels.Events
{
    public class EventInputModel: IMapFrom<Event>
    {
        public DateTime StartEvent { get; set; }

        public DateTime EndEvent { get; set; }

        public int AvailableSpots { get; set; }

        public string Description { get; set; }

        public int ClassId { get; set; }
    }
}

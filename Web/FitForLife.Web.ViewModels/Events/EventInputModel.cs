namespace FitForLife.Web.ViewModels.Events
{
    using FitForLife.Data.Models;
    using FitForLife.Services.Mapping;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EventInputModel: IMapFrom<Event>
    {
        [Required]
        public DateTime StartEvent { get; set; }
        [Required]
        public DateTime EndEvent { get; set; }
        [Required]
        public int AvailableSpots { get; set; }

        public string Description { get; set; }
        [Required]
        public int ClassId { get; set; }
    }
}

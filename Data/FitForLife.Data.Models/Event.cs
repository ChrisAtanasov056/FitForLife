using FitForLife.Data.Common.Models;
using System;
using System.Collections.Generic;

namespace FitForLife.Data.Models
{
   public class Event : BaseDeletableModel<string>
    {
        public Event()
        {
            Appointments = new List<Appointment>();
            this.Id = Guid.NewGuid().ToString();
        }
        public DateTime StartEvent { get; set; }

        public DateTime EndEvent { get; set; }

        public int AvailableSpots { get; set; }

        public string Description { get; set; }

        public int ClassId { get; set; }

        public Class Class { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}


using FitForLife.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitForLife.Tests.Data
{
    public class Events
    {
        public static List<Event> FiveEvents
           => Enumerable.Range(0, 5).Select(i => new Event
           {
               StartEvent = DateTime.Now,
               EndEvent = DateTime.Now.AddMinutes(60),
               AvailableSpots = 10,
               Class = new Class { Name = "Test" },
           }).ToList();
    }
}

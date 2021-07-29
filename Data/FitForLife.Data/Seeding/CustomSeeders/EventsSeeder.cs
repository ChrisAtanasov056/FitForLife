using FitForLife.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FitForLife.Data.Seeding.CustomSeeders
{
    public class EventsSeeder : ISeeder
    {
        public async Task SeedAsync(FitForLifeDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Events.Any())
            {
                return;
            }
            var Events = new Event[]
            {
                new Event
                {
                    StartEvent = DateTime.UtcNow,
                    EndEvent = DateTime.Now.AddHours(1),
                    ClassId = dbContext.Classes.FirstOrDefault(x => x.Name == "Pilates").Id,
                    AvailableSpots = 20,
                },
                new Event
                {
                    StartEvent = DateTime.UtcNow.AddHours(2),
                    EndEvent = DateTime.Now.AddHours(3),
                    ClassId = dbContext.Classes.FirstOrDefault(x => x.Name == "Yoga").Id,
                    AvailableSpots = 10,
                },
                new Event
                {
                    StartEvent = DateTime.UtcNow.AddDays(1),
                    EndEvent = DateTime.Now.AddDays(1).AddHours(1),
                    ClassId = dbContext.Classes.FirstOrDefault(x => x.Name == "Kango Jumps").Id,
                    AvailableSpots = 15,
                },
                new Event
                {
                    StartEvent = DateTime.UtcNow.AddDays(1).AddHours(4),
                    EndEvent = DateTime.Now.AddDays(1).AddHours(5),
                    ClassId = dbContext.Classes.FirstOrDefault(x => x.Name == "Bodybuilding").Id,
                    AvailableSpots = 5,
                },
                new Event
                {
                    StartEvent = DateTime.UtcNow.AddDays(2).AddHours(5),
                    EndEvent = DateTime.Now.AddDays(2).AddHours(6),
                    ClassId = dbContext.Classes.FirstOrDefault(x => x.Name == "Zumba").Id,
                    AvailableSpots = 16,
                },
            };
            foreach (var @event in Events)
            {
                await dbContext.AddAsync(@event);
                await dbContext.SaveChangesAsync();
            }

        }
    }
}

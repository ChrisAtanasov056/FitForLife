namespace FitForLife.Services.Data.Events
{
    using FitForLife.Data.Common.Repositories;
    using FitForLife.Data.Models;
    using FitForLife.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EventService : IEventService
    {
        private readonly IDeletableEntityRepository<FitForLifeUser> userRepository;
        private readonly IDeletableEntityRepository<Event> eventRepository;
        private readonly IDeletableEntityRepository<Card> cardRepository;

        public EventService(IDeletableEntityRepository<Event> eventRepository, IDeletableEntityRepository<FitForLifeUser> userRepository, IDeletableEntityRepository<Card> cardRepository)
        {
            this.eventRepository = eventRepository;
            this.userRepository = userRepository;
            this.cardRepository = cardRepository;
        }

        public async Task<Event> AddUserToEvent(string userId, int eventId)
        {

            var @event = await eventRepository.All()
               .Where(x => x.Id == eventId)
               .FirstOrDefaultAsync();
            if (@event.AvailableSpots>0)
            {
                var user = await userRepository
                    .All()
                    .Where(x => x.Id == userId)
                    .FirstOrDefaultAsync();
                if (!user.Appointments.Any(x=>x.EventId == eventId))
                {
                    return @event;
                }
                var appointment = new Appointment
                {
                    EventId = eventId,
                    UserId = userId
                };
                var curCard = cardRepository
                .All()
                .Where(x => x.Id == user.CardId)
                .FirstOrDefault();
                user.Card = curCard;
                user.Card.Visits -= 1;
                @event.AvailableSpots -= 1;
                user.Appointments.Add(appointment);
                @event.Appointments.Add(appointment);
                await eventRepository.SaveChangesAsync();
                await userRepository.SaveChangesAsync();
            }
            return @event;
        }

        public async Task<List<T>> GetAllEventsAsync<T>()
        {
            var events = await this.eventRepository
                 .All()
                 .To<T>()
                 .ToListAsync();

            return events;
        }
        
        public async Task<T> GetByIdAsync<T>(int id)
        {
            var @event = await this.eventRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return @event;
        }
    }
}

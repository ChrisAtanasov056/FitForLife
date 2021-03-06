namespace FitForLife.Services.Data.Events
{
    using FitForLife.Data.Common.Repositories;
    using FitForLife.Data.Models;
    using FitForLife.Services.Data.Cards;
    using FitForLife.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EventService : IEventService
    {
        private readonly IDeletableEntityRepository<FitForLifeUser> userRepository;
        private readonly IDeletableEntityRepository<Event> eventRepository;
        private readonly IDeletableEntityRepository<Card> cardRepository;
        private readonly ICardsService cardService;

        public EventService(IDeletableEntityRepository<Event> eventRepository, IDeletableEntityRepository<FitForLifeUser> userRepository, IDeletableEntityRepository<Card> cardRepository, ICardsService cardService)
        {
            this.eventRepository = eventRepository;
            this.userRepository = userRepository;
            this.cardRepository = cardRepository;
            this.cardService = cardService;
        }

        public async Task AddAsync(int classId, DateTime startEvent, DateTime endEvent, int availableSpots, string description)
        {
            await this.eventRepository.AddAsync(new Event
            {
                StartEvent = startEvent,
                EndEvent = endEvent,
                AvailableSpots = availableSpots,
                ClassId = classId,
                Description = description
            }); 
            await this.eventRepository.SaveChangesAsync();
        }

        public async Task<Event> AddUserToEvent(string userId, string eventId)
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
                if (user.Appointments.Any(x=>x.EventId == eventId))
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
                if (curCard == null)
                {
                    return @event = null;
                }
                user.Card = curCard;
                if (user.Card.Visits > 0 && user.Appointments.Any(x=> x.EventId != @eventId))
                {
                    user.Card.Visits -= 1;
                    @event.AvailableSpots -= 1;
                    user.Appointments.Add(appointment);
                    @event.Appointments.Add(appointment);
                }
                if (user.Card.Visits == 0)
                {
                    await this.cardService.DeleteAsync(user.Card.Id);
                }

                await eventRepository.SaveChangesAsync();
                await userRepository.SaveChangesAsync();
            }
            return @event;
        }

        public async Task DeleteAsync(string id)
        {
            var @event = await this.eventRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.eventRepository.Delete(@event);
            await this.eventRepository.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllEventsAsync<T>()
        {
            var events = await this.eventRepository
                 .All()
                 .To<T>()
                 .ToListAsync();

            return events;
        }
        
        public async Task<T> GetByIdAsync<T>(string id)
        {
            var @event = await this.eventRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return @event;
        }
    }
}

namespace FitForLife.Tests.Services
{
    using FitForLife.Data.Models;
    using FitForLife.Services.Data.Events;
    using FitForLife.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using NLipsum.Core;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class EventServiceTests : BaseServiceTests
    {
        private IEventService Service => this.ServiceProvider.GetRequiredService<IEventService>();
        //Task<List<T>> GetAllEventsAsync<T>();
        [Fact]
        public async Task GetAllAsyncShoudWorkCorrectly()
        {
            await this.CreateEventAsync();
            await this.CreateEventAsync();
            await this.CreateEventAsync();

            var testEvents = await this.Service.GetAllEventsAsync<TestEventModel>();

            Assert.Equal(3, testEvents.Count);

        }
        //Task DeleteAsync(string id);
        [Fact]
        public async Task DeleteAsyncShouldDeleteCorrectly()
        {
            var @event = await this.CreateEventAsync();

            await this.Service.DeleteAsync(@event.Id);

            var eventsCount = this.DbContext.Events.Where(x => !x.IsDeleted).ToList().Count();
            var deletedEvent = await this.DbContext.Events.FirstOrDefaultAsync(x => x.Id == @event.Id);
            Assert.Equal(0, eventsCount);
            Assert.Null(deletedEvent);
        }
        //Task<T> GetByIdAsync<T>(string id);
        [Fact]
        public async Task GetByIdAsync()
        {
            var @event = await this.CreateEventAsync();


            var returnClass = await this.Service.GetByIdAsync<TestEventModel>(@event.Id);

            Assert.Equal(@event.Id, returnClass.Id);

        }
        //Task<Event> AddUserToEvent(string userId, string eventId);
        
        //Task AddAsync(int classId, DateTime startEvent, DateTime endEvent, int availableSpots, string description);
        [Fact]
        public async Task AddAsyncShouldAddCorrectly()
        {
            await this.CreateEventAsync();

            var eventsCount = await this.DbContext.Events.CountAsync();

            Assert.Equal(1, eventsCount);
        }
        private async Task<Event> CreateEventAsync()
        {
            var @event = new Event
            {
                StartEvent = DateTime.UtcNow,
                EndEvent = DateTime.UtcNow.AddHours(1),
                Description = new Sentence().ToString(),
            };

            await this.DbContext.Events.AddAsync(@event);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Event>(@event).State = EntityState.Detached;
            return @event;
        }
       
        public class TestEventModel : IMapFrom<Event>
        {
            public string Id { get; set; }
        }
    }
}

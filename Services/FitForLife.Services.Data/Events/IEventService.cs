using FitForLife.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitForLife.Services.Data.Events
{
    public interface IEventService
    {
        Task<List<T>> GetAllEventsAsync<T>();

       

        Task<T> GetByIdAsync<T>(int id);

        public Task<Event> AddUserToEvent(string userId, int eventId);
    }
}

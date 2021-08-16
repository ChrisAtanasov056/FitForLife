using FitForLife.Data.Models;
using FitForLife.Web.ViewModels.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitForLife.Services.Data.Events
{
    public interface IEventService
    {
        Task<List<T>> GetAllEventsAsync<T>();

        Task DeleteAsync(string id);

        Task<T> GetByIdAsync<T>(string id);

        Task<Event> AddUserToEvent(string userId, string eventId);

        Task AddAsync(int classId, DateTime startEvent, DateTime endEvent, int availableSpots, string description);
    }
}

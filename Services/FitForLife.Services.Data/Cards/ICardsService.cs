namespace FitForLife.Services.Data.Cards
{
    using FitForLife.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICardsService
    {
        Task<List<T>> GetAllAsync<T>(int? count = null);

        Task<T> GetByIdAsync<T>(int id);

        Task AddAsync(string name, decimal price, int visits);

        Task DeleteAsync(int id);

    }
}

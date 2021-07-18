namespace FitForLife.Services.Data.Classes
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IClassesService
    {
        Task<List<T>> GetAllAsync<T>(int? count = null);

        Task<T> GetByIdAsync<T>(int id);

        Task AddAsync(string name, string description, string imageUrl);

        Task DeleteAsync(int id);
    }
}

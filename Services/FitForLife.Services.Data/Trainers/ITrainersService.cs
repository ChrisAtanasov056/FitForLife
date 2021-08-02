namespace FitForLife.Services.Data.Trainers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITrainersService
    {
        public Task<List<T>> GetAllTrainersAsync<T>();

        Task AddAsync(string firstName, string LastName, string imageUrl, string email , string password , int age , string city, string description , int classId);
        
        Task DeleteAsync(string id);
    }
}

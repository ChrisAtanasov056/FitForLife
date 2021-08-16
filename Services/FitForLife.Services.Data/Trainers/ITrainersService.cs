namespace FitForLife.Services.Data.Trainers
{
    using FitForLife.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITrainersService
    {
        Task<List<T>> GetAllTrainersAsync<T>(int? count = null);

        Task<List<ClientTrainer>> GetAllClients<T>(string id);

        Task<T> GetTrainerById<T>(string id);

        Task AddUserToTrainer(string trainerId, string clientId);

        Task AddAsync(string firstName, string LastName, string imageUrl, string email , string password , int age , string city, string description , int classId);
        
        Task DeleteAsync(string id);
    }
}

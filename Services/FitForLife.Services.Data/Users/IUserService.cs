namespace FitForLife.Services.Data.Users
{
    using FitForLife.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        public Task<string> GetFirstNameAsync(string id);

        public Task<string> GetLastNameAsync(string id);


        public Task<string> GetProfilePictureUrlAsync(string id);

        public Task<FitForLifeUser> ChangeFirstNameAsync(string id, string firstName);

        public Task<FitForLifeUser> ChangeLastNameAsync(string id, string lastName);

        public Task<FitForLifeUser> ChangeEmailAsync(string userId, string newEmail);

        public Task<FitForLifeUser> GetUserByIdAsync(string id);

        public Task<T> GetUserByIdAsync<T>(string id);

        public Task<FitForLifeUser> AddCardToUser(string userId, int cardId);

        public Task<List<T>> GetAllEventsOnUserAsync<T>(string userId);
    }
}

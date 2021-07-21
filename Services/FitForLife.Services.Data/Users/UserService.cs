namespace FitForLife.Services.Data.Users
{
    using FitForLife.Data.Common.Repositories;
    using FitForLife.Data.Models;
    using FitForLife.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<FitForLifeUser> users;

        public UserService(IDeletableEntityRepository<FitForLifeUser> users)
        {
            this.users = users;
        }

        public async Task<FitForLifeUser> ChangeEmailAsync(string userId, string newEmail)
        {
            var user = await this.users
                .All()
                .FirstOrDefaultAsync(x => x.Id == userId);

            user.Email = newEmail;
            await this.users.SaveChangesAsync();

            return user;
        }

        public async Task<FitForLifeUser> ChangeFirstNameAsync(string id, string firstName)
        {
            var user = await this.users
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            user.FirstName = firstName;
            await this.users.SaveChangesAsync();

            return user;
        }

        public async Task<FitForLifeUser> ChangeLastNameAsync(string id, string lastName)
        {
            var user = await this.users
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            user.LastName = lastName;
            await this.users.SaveChangesAsync();

            return user;
        }

        public async Task<FitForLifeUser> ChangeProfilePhotoAsync(string userId, string newProfilePhotoUrl)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<string>> GetAllEmailsAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllUsersAsync<T>(string trainerId = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetCardPictureUrlAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> GetFirstNameAsync(string id)
        {
            var user = await this.users
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            return user.FirstName;
        }

        public async Task<string> GetLastNameAsync(string id)
        {
            var user = await this.users
                  .All()
                  .FirstOrDefaultAsync(x => x.Id == id);

            return user.LastName;
        }

        public async Task<string> GetProfilePictureUrlAsync(string id)
        {
            var user = await this.users
                   .All()
                   .FirstOrDefaultAsync(x => x.Id == id);

            return user.LastName;
        }

        public async Task<FitForLifeUser> GetUserByIdAsync(string id)
        {
            return await this.users
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetUserByIdAsync<T>(string id)
        {
            return await this.users
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstAsync();
        }

        public Task<int> GetUsersCountAsync(string trainerId = null)
        {
            throw new System.NotImplementedException();
        }
    }
}

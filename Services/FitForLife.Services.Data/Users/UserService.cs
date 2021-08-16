namespace FitForLife.Services.Data.Users
{
    using FitForLife.Data.Common.Repositories;
    using FitForLife.Data.Models;
    using FitForLife.Services.Mapping;
    using FitForLife.Web.ViewModels;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<FitForLifeUser> users;
        private readonly IDeletableEntityRepository<Card> cardsRepository;
        private readonly IDeletableEntityRepository<Appointment> appointmentRepository;

        public UserService(IDeletableEntityRepository<FitForLifeUser> users, IDeletableEntityRepository<Card> cardsRepository, IDeletableEntityRepository<Appointment> appointmentRepository)
        {
            this.users = users;
            this.cardsRepository = cardsRepository;
            this.appointmentRepository = appointmentRepository;
        }

        public async Task<FitForLifeUser> AddCardToUser(string userId, int cardId)
        {
            var curUser = users.All()
                .Where(x => x.Id == userId)
                .FirstOrDefault();
            if (curUser.CardId != null)
            {
                return curUser;
            }
            var curCard = cardsRepository
                .All()
                .Where(x => x.Id == cardId)
                .FirstOrDefault();
            curUser.Card = curCard;
            await users.SaveChangesAsync();
            return curUser;
        }
        public async Task<List<T>> GetAllEventsOnUserAsync<T>(string userId)
        {
            var events = await this.appointmentRepository
                 .All()
                 .Where(x => x.UserId == userId)
                 .To<T>()
                 .ToListAsync();

            return events;
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

    }
}

namespace FitForLife.Services.Data.Cards
{
    using FitForLife.Data.Common.Repositories;
    using FitForLife.Data.Models;
    using FitForLife.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CardsServices : ICardsService
    {
        private readonly IDeletableEntityRepository<Card> cardRepository;

        public CardsServices(IDeletableEntityRepository<Card> cardRepository)
        {
            this.cardRepository = cardRepository;
        }

        public Task AddAsync(string name, decimal price, int visits)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var card =
                await this.cardRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.cardRepository.Delete(card);
            await this.cardRepository.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync<T>(int? count = null)
        {
            IQueryable<Card> query =
                this.cardRepository
                .All()
                .OrderBy(x => x.Id);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return await query.To<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var card =
                await this.cardRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return card;
        }
    }
}

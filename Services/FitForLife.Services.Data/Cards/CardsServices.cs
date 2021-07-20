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

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
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

        public Task<T> GetByIdAsync<T>(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

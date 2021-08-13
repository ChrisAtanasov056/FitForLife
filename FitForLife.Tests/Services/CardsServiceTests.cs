namespace FitForLife.Tests.Services
{
    using FitForLife.Data.Models;
    using FitForLife.Services.Data.Cards;
    using FitForLife.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class CardsServiceTests : BaseServiceTests
    {
        private ICardsService Service => this.ServiceProvider.GetRequiredService<ICardsService>();

        //Task<List<T>> GetAllAsync<T>(int? count = null);
        [Fact]
        public async Task GetAllAsyncShoudWorkCorrectly()
        {
            await this.CreateCardAsync();
            await this.CreateCardAsync();
            await this.CreateCardAsync();

            var testCards = await this.Service.GetAllAsync<TestCardModel>();

            Assert.Equal(3, testCards.Count);

        }
        //Task<T> GetByIdAsync<T>(int id);
        [Fact]
        public async Task GetByIdAsyncShoudWorkCorrectly()
        {
            var card = await this.CreateCardAsync();

            var returnBlog = await this.Service.GetByIdAsync<TestCardModel>(card.Id);

            Assert.Equal(card.Id, returnBlog.Id);
            Assert.Equal(card.Name, returnBlog.Name);

        }
        //Task AddAsync(string name, decimal price, int visits);
        [Fact]
        public async Task AddAsyncShouldAddCorrectly()
        {
            await this.CreateCardAsync();

            var cardCount = await this.DbContext.Cards.CountAsync();

            Assert.Equal(1, cardCount);
        }
        //Task DeleteAsync(int id);
        [Fact]
        public async Task DeleteAsyncShouldDeleteCorrectly()
        {
            var card = await this.CreateCardAsync();

            await this.Service.DeleteAsync(card.Id);

            var cardsCount = this.DbContext.Cards.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedCard = await this.DbContext.Cards.FirstOrDefaultAsync(x => x.Id == card.Id);
            Assert.Equal(0, cardsCount);
            Assert.Null(deletedCard);
        }
        private async Task<Card> CreateCardAsync()
        {
            var card = new Card
            {
                Name = "Test Title",
                Price = 29.99m,
                Visits = 10,
            };

            await this.DbContext.Cards.AddAsync(card);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Card>(card).State = EntityState.Detached;
            return card;
        }
        public class TestCardModel : IMapFrom<Card>
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}


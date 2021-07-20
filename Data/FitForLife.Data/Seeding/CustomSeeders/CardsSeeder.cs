namespace FitForLife.Data.Seeding.CustomSeeders
{
    using FitForLife.Data.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class CardsSeeder : ISeeder
    {
        public async Task SeedAsync(FitForLifeDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cards.Any())
            {
                return;
            }
            var cards = new Card[]
            {
                new Card
               {
                   Name = "One Visit",
                   Price = 4m,
                   Visits = 1,
               },
               new Card
               {
                   Name = "Silver",
                   Price = 12.99m,
                   Visits = 10,
               },
               new Card
               {
                   Name = "Gold",
                   Price = 24.99m,
                   Visits = 20,
               },
               new Card
               {
                   Name = "Premium",
                   Price = 32.99m,
                   Visits = 30,
               }

            };

            foreach (var card in cards)
            {
                await dbContext.AddAsync(card);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

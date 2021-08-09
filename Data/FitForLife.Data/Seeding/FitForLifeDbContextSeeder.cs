namespace FitForLife.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FitForLife.Data.Seeding.CustomSeeders;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    public class FitForLifeDbContextSeeder : ISeeder
    {
        public async Task SeedAsync(FitForLifeDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger(typeof(FitForLifeDbContextSeeder));

            var seeders = new List<ISeeder>
                          {
                              new RolesSeeder(),
                              new ClassesSeeder(),
                              new AccountsSeeder(),
                              new CardsSeeder(),
                              new BlogsSeeder(),
                              new EventsSeeder(),
                              new ExercisesSeeder()
                          };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}

    

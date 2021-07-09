namespace FitForLife.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(FitForLifeDbContext dbContext, IServiceProvider serviceProvider);
    }
}

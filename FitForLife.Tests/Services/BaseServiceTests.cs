
namespace FitForLife.Tests.Services
{
    using FitForLife.Data;
    using FitForLife.Data.Common.Repositories;
    using FitForLife.Data.Repositories;
    using FitForLife.Services.Data;
    using FitForLife.Services.Data.Blog;
    using FitForLife.Services.Data.Cards;
    using FitForLife.Services.Data.Classes;
    using FitForLife.Services.Data.Events;
    using FitForLife.Services.Data.Exercises;
    using FitForLife.Services.Data.Trainers;
    using FitForLife.Services.Data.Users;
    using FitForLife.Services.Mapping;
    using FitForLife.Web.ViewModels;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Reflection;

    public abstract class BaseServiceTests : IDisposable
    {
        protected IServiceProvider ServiceProvider { get; set; }

        protected FitForLifeDbContext DbContext { get; set; }

        public BaseServiceTests()
        {
            var service = SetServices();
            this.ServiceProvider = service.BuildServiceProvider();
            this.DbContext = this.ServiceProvider.GetRequiredService<FitForLifeDbContext>();
               
        }
        public void Dispose()
        {
            this.DbContext.Database.EnsureDeleted();
            SetServices();
        }
        private static ServiceCollection SetServices()
        {
            var services = new ServiceCollection();

            AutoMapperConfig.RegisterMappings(Assembly.Load("FitForLife.Tests"), typeof(ErrorViewModel)
               .GetTypeInfo()
               .Assembly);

            services.AddDbContext<FitForLifeDbContext>(
                options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            // Application services
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<ICardsService, CardsServices>();
            services.AddTransient<IClassesService, ClassesService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IExercisesService, ExercisesService>();
            services.AddTransient<ITrainersService, TrainersService>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}

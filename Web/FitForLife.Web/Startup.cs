namespace FitForLife
{
    using FitForLife.Data;
    using FitForLife.Data.Common;
    using FitForLife.Data.Common.Repositories;
    using FitForLife.Data.Models;
    using FitForLife.Data.Repositories;
    using FitForLife.Data.Seeding;
    using FitForLife.Models;
    using FitForLife.Services.Data;
    using FitForLife.Services.Data.Blog;
    using FitForLife.Services.Data.Cards;
    using FitForLife.Services.Data.Classes;
    using FitForLife.Services.Data.Events;
    using FitForLife.Services.Data.Exercises;
    using FitForLife.Services.Data.Trainers;
    using FitForLife.Services.Data.Users;
    using FitForLife.Services.Data.WorkoutPlan;
    using FitForLife.Services.Mapping;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System.Reflection;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FitForLifeDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
           
            services.AddDefaultIdentity<FitForLifeUser>
                (IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<FitForLifeRole>()
                .AddEntityFrameworkStores<FitForLifeDbContext>()
                .AddDefaultTokenProviders();

            services.AddSingleton(this.configuration);
            // fb Login
            services.AddAuthentication()
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = this.configuration["Authentication:Facebook:AppId"];
                    facebookOptions.AppSecret = this.configuration["Authentication:Facebook:AppSecret"];
                    facebookOptions.Scope.Add("public_profile");
                    facebookOptions.Fields.Add("name");
                    facebookOptions.Fields.Add("picture");
                });

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddCoreAdmin();

            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            //App Services
            services.AddTransient<IClassesService, ClassesService>();
            services.AddTransient<ICardsService, CardsServices>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITrainersService, TrainersService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<IExercisesService, ExercisesService>();
            services.AddTransient<IWorkoutPlanService, WorkoutPlanService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(Assembly.Load("FitForLife.Web.ViewModels"),typeof(ErrorViewModel)
                .GetTypeInfo()
                .Assembly);
            
            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<FitForLifeDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new FitForLifeDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }
            if (env.IsDevelopment())
            {
                
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapRazorPages();
                });
        }
    }
}

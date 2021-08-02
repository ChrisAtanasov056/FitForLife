namespace FitForLife.Services.Data.Trainers
{
    using FitForLife.Common;
    using FitForLife.Data.Common.Repositories;
    using FitForLife.Data.Models;
    using FitForLife.Services.Mapping;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TrainersService : ITrainersService
    {
        private readonly IDeletableEntityRepository<FitForLifeUser> trainersRepository;
        private readonly RoleManager<FitForLifeRole> roleManager;
        private readonly string trainerRoleId;
        private readonly IServiceProvider serviceProvider;
        public TrainersService(IDeletableEntityRepository<FitForLifeUser> trainersRepository, RoleManager<FitForLifeRole> roleManager, IServiceProvider serviceProvider)
        {
            this.trainersRepository = trainersRepository;
            this.serviceProvider = serviceProvider;
            this.roleManager = roleManager;
            this.trainerRoleId = this.roleManager
                .Roles
                .First(x => x.Name.ToLower() == GlobalConstants.TrainerRoleName.ToLower())
                .Id;
            
        }

        public async Task AddAsync(string firstName, string LastName, string imageUrl, string email, string password , int age , string city , string description , int classId)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<FitForLifeUser>>();
            var trainer = new FitForLifeUser()
            {
                FirstName = firstName,
                LastName = LastName,
                ProfilePictureUrl = imageUrl,
                Email = email,
                UserName = email,
                Description = description,
                ClassId = classId,
                Age = age,
                City = city,
            };
            if (trainer != null)
            {
                var role = await roleManager.FindByNameAsync(GlobalConstants.TrainerRoleName);
                var result = await userManager.CreateAsync(trainer, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(trainer, role.Name);
                }
            }
            await trainersRepository.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllTrainersAsync<T>()
        {
            var trainers = await this.trainersRepository
                 .All()
                 .Where(x => x.Roles.Any(y => y.RoleId == this.trainerRoleId))
                 .To<T>()
                 .ToListAsync();

            return trainers;
        }
        public async Task DeleteAsync(string id)
        {
            var trainer = await this.trainersRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.trainersRepository.Delete(trainer);
            await this.trainersRepository.SaveChangesAsync();
        }
    }
}

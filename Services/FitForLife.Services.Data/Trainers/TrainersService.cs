namespace FitForLife.Services.Data.Trainers
{
    using FitForLife.Common;
    using FitForLife.Data.Common.Repositories;
    using FitForLife.Data.Models;
    using FitForLife.Services.Mapping;
    using FitForLife.Web.ViewModels.Trainers;
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
        private readonly IDeletableEntityRepository<ClientTrainer> clientTrainerRepository;
        private readonly RoleManager<FitForLifeRole> roleManager;
        private readonly string trainerRoleId;
        private readonly IServiceProvider serviceProvider;
        public TrainersService(IDeletableEntityRepository<FitForLifeUser> trainersRepository, RoleManager<FitForLifeRole> roleManager, IServiceProvider serviceProvider, IDeletableEntityRepository<ClientTrainer> clientTrainerRepository)
        {
            this.trainersRepository = trainersRepository;
            this.serviceProvider = serviceProvider;
            this.roleManager = roleManager;
            this.trainerRoleId = this.roleManager
                .Roles
                .First(x => x.Name.ToLower() == GlobalConstants.TrainerRoleName.ToLower())
                .Id;
            this.clientTrainerRepository = clientTrainerRepository;
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
            var trainer = GetTrainerById<FitForLifeUser>(id).Result;
            this.trainersRepository.Delete(trainer);
            await this.trainersRepository.SaveChangesAsync();
        }

        public async Task<List<ClientTrainer>> GetAllClients<T>(string id)
        {
            var clients = await this.clientTrainerRepository
                .All()
                .Where(x => x.TrainerId == id)
                
                .ToListAsync();
            
            foreach (var client in clients)
            {
                var curClient =  await this.trainersRepository.All()
                    .Where(x => x.Id == client.ClientId)
                    .FirstOrDefaultAsync();
                client.Client = curClient;
            }
            return clients;
        }
        public async Task<T> GetTrainerById<T>(string id)
        {
            var trainer = await this.trainersRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
            return trainer;
        }

        public async Task AddUserToTrainer(string trainerId, string clientId)
        {
           var trainer = await this.trainersRepository
                .All()
                .Where(x => x.Id == trainerId)
                .FirstOrDefaultAsync();
            var Client = await this.trainersRepository
                 .All()
                 .Where(x => x.Id == clientId)
                 .FirstOrDefaultAsync();
            var ClientTrainer = new ClientTrainer
            {
                ClientId = clientId,
                Client = Client,
                TrainerId = trainerId,
                Trainer = trainer,
            };
            trainer.Clients.Add(ClientTrainer);
            await clientTrainerRepository.SaveChangesAsync();
            await trainersRepository.SaveChangesAsync();
        }
    }
}

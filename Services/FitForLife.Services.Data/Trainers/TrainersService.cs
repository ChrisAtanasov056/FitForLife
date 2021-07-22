namespace FitForLife.Services.Data.Trainers
{
    using FitForLife.Common;
    using FitForLife.Data.Common.Repositories;
    using FitForLife.Data.Models;
    using FitForLife.Services.Mapping;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TrainersService : ITrainersService
    {
        private readonly IDeletableEntityRepository<FitForLifeUser> trainersRepository;
        private readonly RoleManager<FitForLifeRole> roleManager;
        private readonly IDeletableEntityRepository<ClientTrainer> clientTrainersRepository;
        private readonly string trainerRoleId;
        public TrainersService(IDeletableEntityRepository<FitForLifeUser> trainersRepository, RoleManager<FitForLifeRole> roleManager)
        {
            this.trainersRepository = trainersRepository;
            this.roleManager = roleManager;
            this.trainerRoleId = this.roleManager
                .Roles
                .First(x => x.Name.ToLower() == GlobalConstants.TrainerRoleName.ToLower())
                .Id;
            
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
    }
}

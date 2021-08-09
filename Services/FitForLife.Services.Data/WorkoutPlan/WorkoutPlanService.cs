
namespace FitForLife.Services.Data.WorkoutPlan
{
    using FitForLife.Data.Common.Repositories;
    using FitForLife.Web.ViewModels.WorkoutPlan;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FitForLife.Data.Models;
    using System.Linq;
    using FitForLife.Data.Models.Enums;
    using FitForLife.Services.Data.Users;

    public class WorkoutPlanService : IWorkoutPlanService
    {
        private readonly IDeletableEntityRepository<WorkoutPlan> workoutPlanRepository;
        private readonly IDeletableEntityRepository<FitForLifeUser> clientRepository;
        private readonly IUserService userService;

        public WorkoutPlanService(IDeletableEntityRepository<WorkoutPlan> workoutPlanRepository, IDeletableEntityRepository<FitForLifeUser> clientRepository, IUserService userService)
        {
            this.workoutPlanRepository = workoutPlanRepository;
            this.clientRepository = clientRepository;
            this.userService = userService;
        }

        public async Task AddProgramAsync(AllTrainingDaysInput trainingDays)
        {
            Difficulty difficulty = FindDiffilculty(trainingDays.TrainingDayInputs);
            var curTrainigDays = new List<TrainingDay>();
            foreach (var trainingDayInput in trainingDays.TrainingDayInputs)
            {
                curTrainigDays.Add(new TrainingDay()
                {
                    Exercises = trainingDayInput.Exercises,
                });
            }
            var workoutPlan = new WorkoutPlan
            {
                TrainingDays = curTrainigDays,
                Difficulty = difficulty,
                DaysInWeek = trainingDays.TrainingDayInputs.Count,
                UserId = trainingDays.UserId
            };
            await this.workoutPlanRepository.AddAsync(workoutPlan);
            var user = await this.userService.GetUserByIdAsync(trainingDays.UserId);
            user.WorkoutPlanId = workoutPlan.Id;
            await workoutPlanRepository.SaveChangesAsync();
            await clientRepository.SaveChangesAsync();
        }

        private static Difficulty FindDiffilculty(List<TrainingDayInputModel> trainingDays)
        {
            var difficulties = trainingDays.SelectMany(x => x.Exercises.Select(x => x.Difficulty));
            var easy = 0;
            var medium = 0;
            var hard = 0;
            Difficulty difficulty = Difficulty.Easy;
            foreach (var diff in difficulties)
            {
                if (diff == Difficulty.Easy)
                {
                    easy += 1;
                }
                if (diff == Difficulty.Medium)
                {
                    medium += 1;
                }
                if (diff == Difficulty.Hard)
                {
                    hard += 1;
                }
            }
            if (medium > easy && medium > hard)
            {
                difficulty = Difficulty.Medium;
            }
            if (hard > easy && hard > medium)
            {
                difficulty = Difficulty.Hard;
            }

            return difficulty;
        }
    }
}

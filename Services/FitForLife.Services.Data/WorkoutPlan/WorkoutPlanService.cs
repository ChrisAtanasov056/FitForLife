
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
    using FitForLife.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class WorkoutPlanService : IWorkoutPlanService
    {
        private readonly IDeletableEntityRepository<WorkoutPlan> workoutPlanRepository;
        private readonly IDeletableEntityRepository<FitForLifeUser> clientRepository;
        private readonly IDeletableEntityRepository<Exercise> exerciseRepository;
        private readonly IUserService userService;

        public WorkoutPlanService(IDeletableEntityRepository<WorkoutPlan> workoutPlanRepository, IDeletableEntityRepository<FitForLifeUser> clientRepository, IUserService userService, IDeletableEntityRepository<Exercise> exerciseRepository)
        {
            this.workoutPlanRepository = workoutPlanRepository;
            this.clientRepository = clientRepository;
            this.userService = userService;
            this.exerciseRepository = exerciseRepository;
        }

        public async Task AddProgramAsync(AllTrainingDaysInput trainingDays)
        {
            Difficulty difficulty = FindDiffilculty(trainingDays.TrainingDayInputs);
            var curTrainigDays = new List<TrainingDay>();
           
            
            foreach (var trainingDayInput in trainingDays.TrainingDayInputs)
            {
                var curExerciseOftheDay = new List<Exercise>();
                foreach (var exercise in trainingDayInput.Exercises)
                {
                    curExerciseOftheDay.Add(await this.exerciseRepository.All()
                        .Where(x=>x.Id == exercise.Id)
                        .FirstOrDefaultAsync());
                }
                curTrainigDays.Add(new TrainingDay()
                {
                    Exercises = curExerciseOftheDay
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

        public async Task<T> GetWorkoutPlanById<T>(string id)
        {
            var workoutPlan = await this.workoutPlanRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
            return workoutPlan;
        }

        public async Task DeletePlan(string id)
        {
           var workoutPlan = await this.workoutPlanRepository
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.workoutPlanRepository.HardDelete(workoutPlan);
            var client= await this.clientRepository.All()
                .Where(x => x.WorkoutPlanId == workoutPlan.Id)
                .FirstOrDefaultAsync();
            client.WorkoutPlan = null;
            client.WorkoutPlanId = null;
            await clientRepository.SaveChangesAsync();
            await workoutPlanRepository.SaveChangesAsync();
        }
    }
}

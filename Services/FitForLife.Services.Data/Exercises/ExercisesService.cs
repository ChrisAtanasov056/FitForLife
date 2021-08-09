namespace FitForLife.Services.Data.Exercises
{
    using FitForLife.Data.Common.Repositories;
    using FitForLife.Data.Models;
    using FitForLife.Services.Data.Exercises;
    using FitForLife.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ExercisesService : IExercisesService
    {
        private readonly IDeletableEntityRepository<Exercise> exerciseRepository;

        public ExercisesService(IDeletableEntityRepository<Exercise> exerciseRepository)
        {
            this.exerciseRepository = exerciseRepository;
        }

        public async Task<List<T>> GetAllExerciseAsync<T>()
        {
            var exercises = await this.exerciseRepository
                 .All()
                 .To<T>()
                 .ToListAsync();
            return exercises;
        }
    }
}

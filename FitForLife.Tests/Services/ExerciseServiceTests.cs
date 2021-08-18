namespace FitForLife.Tests.Services
{
    using FitForLife.Data.Models;
    using FitForLife.Data.Models.Enums;
    using FitForLife.Services.Data.Exercises;
    using FitForLife.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using NLipsum.Core;
    using System.Threading.Tasks;
    using Xunit;

    public class ExerciseServiceTests : BaseServiceTests
    {
       
        private IExercisesService Service => this.ServiceProvider.GetRequiredService<IExercisesService>();


        //Task<List<T>> GetAllExerciseAsync<T>();
        [Fact]
        public async Task GetAllAsyncShoudWorkCorrectly()
        {
            await this.CreateExerciseAsync();
            await this.CreateExerciseAsync();
            await this.CreateExerciseAsync();

            var testExercise = await this.Service.GetAllExerciseAsync<TestExerciseModel>();

            Assert.Equal(3, testExercise.Count);

        }
        private async Task<Exercise> CreateExerciseAsync()
        {
            var exercise = new Exercise
            {
                Name = "Test",
                Difficulty = Difficulty.Easy,
                VideoUrl = Word.Long.ToString()
                
            };

            await this.DbContext.Exercises.AddAsync(exercise);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Exercise>(exercise).State = EntityState.Detached;
            return exercise;
        }
        public class TestExerciseModel : IMapFrom<Exercise>
        {
            public string Id { get; set; }
        }
    }
}

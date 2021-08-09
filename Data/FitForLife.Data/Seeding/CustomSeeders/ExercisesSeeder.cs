namespace FitForLife.Data.Seeding.CustomSeeders
{
    using FitForLife.Data.Models;
    using FitForLife.Data.Models.Enums;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    class ExercisesSeeder : ISeeder
    {
        public async Task SeedAsync(FitForLifeDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Exercises.Any())
            {
                return;
            }
            var exercises = new Exercise[]
            {
                new Exercise
                {
                    Name = "Leg Press",
                    VideoUrl = "https://www.youtube.com/watch?v=GvRgijoJ2xY",
                    Difficulty = Difficulty.Medium,
                    RepsCount = 12,
                    @Type = ExerciseType.Legs
                },
                new Exercise
                {
                    Name = "Dips",
                    VideoUrl = "https://www.youtube.com/watch?v=2z8JmcrW-As",
                    Difficulty = Difficulty.Medium,
                    RepsCount = 10,
                    @Type = ExerciseType.Chest
                },
                new Exercise
                {
                    Name = "Biceps Bar Curls",
                    VideoUrl = "https://www.youtube.com/watch?v=kwG2ipFRgfo",
                    Difficulty = Difficulty.Easy,
                    RepsCount = 15,
                    @Type = ExerciseType.Biceps
                },
                new Exercise
                {
                    Name = "Running",
                    VideoUrl = "https://www.youtube.com/watch?v=brFHyOtTwH4",
                    Difficulty = Difficulty.Easy,
                    RepsCount = 1,
                    @Type = ExerciseType.Cardio
                },
                new Exercise
                {
                    Name = "Bench Press",
                    VideoUrl = "https://www.youtube.com/watch?v=vcBig73ojpE",
                    Difficulty = Difficulty.Medium,
                    RepsCount = 8,
                    @Type = ExerciseType.Chest
                },
                new Exercise
                {
                    Name = "Pull-Ups",
                    VideoUrl = "https://www.youtube.com/watch?v=eGo4IYlbE5g",
                    Difficulty = Difficulty.Medium,
                    RepsCount = 12,
                    @Type = ExerciseType.Back
                },
                new Exercise
                {
                    Name = "Crunches",
                    VideoUrl = "https://www.youtube.com/watch?v=Xyd_fa5zoEU",
                    Difficulty = Difficulty.Easy,
                    RepsCount = 12,
                    @Type = ExerciseType.Abs

                },
                new Exercise
                {
                    Name = "Shoulder Press",
                    VideoUrl = "https://www.youtube.com/watch?v=QAQ64hK4Xxs",
                    Difficulty = Difficulty.Hard,
                    RepsCount = 10,
                    @Type = ExerciseType.Shoulder

                },
                new Exercise
                {
                    Name = "Triceps Extension Lying",
                    VideoUrl = "https://www.youtube.com/watch?v=4re6CJ0XNF8",
                    Difficulty = Difficulty.Hard,
                    RepsCount = 12,
                    @Type = ExerciseType.Triceps

                },
            };
            foreach (var exercise in exercises)
            {
                await dbContext.AddAsync(exercise);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

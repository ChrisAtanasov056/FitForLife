namespace FitForLife.Services.Data.Exercises
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IExercisesService
    {
        Task<List<T>> GetAllExerciseAsync<T>();
    }
}

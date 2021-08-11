
namespace FitForLife.Services.Data.WorkoutPlan
{
    using FitForLife.Web.ViewModels.WorkoutPlan;
    using FitForLife.Data.Models;
    using System.Threading.Tasks;

    public interface IWorkoutPlanService 
    {
        Task AddProgramAsync(AllTrainingDaysInput trainingDays);

        Task<T> GetWorkoutPlanById<T>(string id);

        Task DeletePlan(string id);
    }
}

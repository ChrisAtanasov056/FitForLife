using FitForLife.Web.ViewModels.WorkoutPlan;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitForLife.Services.Data.WorkoutPlan
{
    public interface IWorkoutPlanService 
    {
        Task AddProgramAsync(AllTrainingDaysInput trainingDays);
    }
}

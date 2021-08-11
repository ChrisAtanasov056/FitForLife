namespace FitForLife.Web.ViewModels.WorkoutPlan
{
    using FitForLife.Data.Models.Enums;
    using FitForLife.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using FitForLife.Services.Mapping;

    public class WorkoutPlanViewModel: IMapFrom<WorkoutPlan>
    {
        public Difficulty Difficulty { get; set; }

        public int DaysInWeek { get; set; }

        public TrainingDayViewModel[] TrainingDays { get; set; }
    }
}

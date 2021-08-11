namespace FitForLife.Web.ViewModels.WorkoutPlan
{
    using FitForLife.Data.Models;
    using FitForLife.Data.Models.Enums;
    using FitForLife.Services.Mapping;
    using System.Collections.Generic;

    public class TrainingDayViewModel : IMapFrom<TrainingDay>
    {
        public string Id { get; set; }

        public Day Day { get; set; }

        public string WorkoutPlanId { get; set; }

        public virtual WorkoutPlan WorkoutPlan { get; set; }

        public ExerciseViewModel[] Exercises { get; set; }
    }
}

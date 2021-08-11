using FitForLife.Data.Models;
using FitForLife.Data.Models.Enums;
using System.Collections.Generic;

namespace FitForLife.Web.ViewModels.WorkoutPlan
{
    public class TrainingDayInputModel
    {
        public Day Day { get; set; }

        public string WorkoutPlanId { get; set; }

        public ExerciseInputModel[] Exercises { get; set; }
    }
}

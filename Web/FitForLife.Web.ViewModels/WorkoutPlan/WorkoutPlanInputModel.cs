using FitForLife.Data.Models;
using FitForLife.Data.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitForLife.Web.ViewModels.WorkoutPlan
{
    public class WorkoutPlanInputModel
    {
        [Required]
        public Difficulty Difficulty { get; set; }

        public int DaysInWeek { get; set; }

        public virtual ICollection<TrainingDay> TrainingDays { get; set; }
    }
}

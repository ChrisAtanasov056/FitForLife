using FitForLife.Data.Models;
using System.Collections.Generic;

namespace FitForLife.Web.ViewModels.WorkoutPlan
{
    public class TrainingDayInputModel
    {
       

        public string WorkoutPlanId { get; set; }

        public virtual Exercise[] Exercises { get; set; }
    }
}

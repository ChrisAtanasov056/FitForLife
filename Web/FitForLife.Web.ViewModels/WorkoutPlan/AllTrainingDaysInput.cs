namespace FitForLife.Web.ViewModels.WorkoutPlan
{
    
    using System.Collections.Generic;

    public class AllTrainingDaysInput
    {
        public string UserId { get; set; }

        public List<TrainingDayInputModel> TrainingDayInputs { get; set; } = new List<TrainingDayInputModel>();
    }
}

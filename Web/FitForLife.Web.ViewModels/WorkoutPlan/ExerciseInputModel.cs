namespace FitForLife.Web.ViewModels.WorkoutPlan
{
    using FitForLife.Data.Models.Enums;

    public class ExerciseInputModel 
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Difficulty Difficulty { get; set; }
    }
}

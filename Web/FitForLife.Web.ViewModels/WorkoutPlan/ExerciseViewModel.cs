using FitForLife.Data.Models;
using FitForLife.Data.Models.Enums;
using FitForLife.Services.Mapping;

namespace FitForLife.Web.ViewModels.WorkoutPlan
{
    public class ExerciseViewModel : IMapFrom<Exercise>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int RepsCount { get; set; }

        public string VideoUrl { get; set; }

        public Difficulty Difficulty { get; set; }

        public ExerciseType Type { get; set; }
    }
}

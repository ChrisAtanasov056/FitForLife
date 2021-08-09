namespace FitForLife.Data.Models
{
    using FitForLife.Data.Models.Enums;
    using System;
    using System.Collections.Generic;

    public class TrainingDay
    {
        public TrainingDay()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Exercises = new HashSet<Exercise>();
        }

        public string Id { get; set; }

        public Day Day { get; set; }

        public string WorkoutPlanId { get; set; }

        public virtual WorkoutPlan WorkoutPlan { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}

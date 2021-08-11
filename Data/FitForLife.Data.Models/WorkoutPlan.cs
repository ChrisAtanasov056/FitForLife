namespace FitForLife.Data.Models
{
    using System;
    using System.Collections.Generic;
    using FitForLife.Data.Common.Models;
    using FitForLife.Data.Models.Enums;

    public class WorkoutPlan : IAuditInfo , IDeletableEntity
    {
        public WorkoutPlan()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
            this.TrainingDays = new List<TrainingDay>();
        }

        public string Id { get; set; }

        public Difficulty Difficulty { get; set; }

        public int DaysInWeek { get; set; }

        public string UserId { get; set; }

        public FitForLifeUser User { get; set; }
        // Deletable
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        // AuditInfo
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime ExpireDate { get; set; }

        public bool IsValid
            => this.CreatedOn.Subtract(this.ExpireDate).TotalHours > 0;

        public virtual ICollection<TrainingDay> TrainingDays { get; set; }
    }
}

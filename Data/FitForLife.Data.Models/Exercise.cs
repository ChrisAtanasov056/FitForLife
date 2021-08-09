namespace FitForLife.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using FitForLife.Data.Common.Models;
    using FitForLife.Data.Models.Enums;

    public class Exercise : IDeletableEntity
    {
        public Exercise()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public int RepsCount { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        public Difficulty Difficulty { get; set; }

        public ExerciseType Type { get; set; }
        // Deletable
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}

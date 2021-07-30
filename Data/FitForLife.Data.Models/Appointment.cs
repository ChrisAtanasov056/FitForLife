namespace FitForLife.Data.Models
{
    using FitForLife.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Appointment : IDeletableEntity
    {
        [Key]
        [Required]
        public string UserId { get; set; }

        public FitForLifeUser User { get; set; }
        [Key]
        [Required]
        public int EventId { get; set; }

        public Event Event { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

    }
}
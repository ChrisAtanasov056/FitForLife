namespace FitForLife.Data.Models
{
    using FitForLife.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Appointment : IDeletableEntity
    {
        [Required]
        public int UserId { get; set; }

        public FitForLifeUser User { get; set; }

        [Required]
        public int EventId { get; set; }

        public Event Event { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

    }
}
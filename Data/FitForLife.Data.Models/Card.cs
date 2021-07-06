namespace FitForLife.Data.Models
{
    using FitForLife.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Card : IAuditInfo, IDeletableEntity
    {
        public Card()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Required]
        public string Id { get; set; }

        [Range(0,30)]
        public int Visits { get; set; }

        [Required]
        public string UserId { get; set; }

        public FitForLifeUser User { get; set; }
        
        [Required]
        public string PictureUrl { get; set; }

        // Audit Info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
        
        // Deletable Entity
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
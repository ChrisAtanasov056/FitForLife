namespace FitForLife.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using FitForLife.Data.Common.Models;

    public class Class : BaseDeletableModel<int>
    {
        public Class()
        {
            this.Trainers = new List<FitForLifeUser>();
            this.Events = new List<Event>();
        }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        public ICollection<FitForLifeUser> Trainers { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}

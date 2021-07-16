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
            this.Clients = new HashSet<FitForLifeUser>();
        }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        public int MaxClients { get; set; }

        public ICollection<FitForLifeUser> Clients { get; set; }

    }
}

namespace FitForLife.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using FitForLife.Data.Common.Models;

    public class Class : IAuditInfo, IDeletableEntity
    {
        public Class()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Clients = new HashSet<FitForLifeUser>();
        }
        public string Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }

        public int MaxClients { get; set; }

        public ICollection<FitForLifeUser> Clients { get; set; }

        // Audit Info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
        
        // Deletable Entity
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}

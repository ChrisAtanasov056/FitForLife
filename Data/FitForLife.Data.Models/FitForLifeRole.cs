namespace FitForLife.Data.Models
{
    using System;
    using System.Collections.Generic;
    using FitForLife.Data.Common.Models;
    using Microsoft.AspNetCore.Identity;

    public class FitForLifeRole : IdentityRole , IAuditInfo , IDeletableEntity
    {
        public FitForLifeRole()
            : this(null)
        {
        }
        public FitForLifeRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

        // AuditInfo
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
        
        // Deletable Entity
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }

    }
}

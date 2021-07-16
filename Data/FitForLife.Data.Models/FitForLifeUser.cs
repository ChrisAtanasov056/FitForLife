﻿namespace FitForLife.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using FitForLife.Data.Common.Models;
    using Microsoft.AspNetCore.Identity;

    public class FitForLifeUser : IdentityUser<string>, IAuditInfo , IDeletableEntity
    {
        public FitForLifeUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Trainers = new HashSet<ClientTrainer>();
            this.Clients = new HashSet<ClientTrainer>();
            this.CreatedOn = DateTime.UtcNow;
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
        }
       
        [MaxLength(30)]
        public string FirstName { get; set; }
        
        [MaxLength(30)]
        public string LastName { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string Description { get; set; }

        public string CardId { get; set; }
        
        public Card Card { get; set; }
        // Audit Info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable Entity
        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<ClientTrainer> Trainers { get; set; }
        
        public  ICollection<ClientTrainer> Clients { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
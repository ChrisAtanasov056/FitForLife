namespace FitForLife.Data.Models
{
    using System;
    using FitForLife.Data.Common.Models;

    public class ClientTrainer : IDeletableEntity
    {
        public string ClientId { get; set; }

        public virtual FitForLifeUser Client { get; set; }

        public string TrainerId { get; set; }

        public virtual FitForLifeUser Trainer { get; set; }
        
        // Deletable Entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}

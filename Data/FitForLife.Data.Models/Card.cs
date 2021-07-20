namespace FitForLife.Data.Models
{
    using FitForLife.Data.Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Card : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Visits { get; set; }

        public IEnumerable<FitForLifeUser> Users { get; set; }
    }
}

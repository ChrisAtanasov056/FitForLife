namespace FitForLife.Data.Models
{
    using FitForLife.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment : BaseDeletableModel<string> , IAuditInfo
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }
        [Required]
        [MaxLength(40)]
        public string Author { get; set; }

        [Required]
        public string Context { get; set; }

        public string BlogId { get; set; }

        public Blog Blog { get; set; }
    }
}

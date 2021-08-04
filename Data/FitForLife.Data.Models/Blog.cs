namespace FitForLife.Data.Models
{
    using FitForLife.Data.Common.Models;
    using FitForLife.Data.Models.Enums;
    using System;

    public class Blog : IDeletableEntity
    {
        public Blog()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; init; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public string ImageUrl { get; set; }

        public string Context { get; set; }

        public TypeBlog TypeBlog { get; set; }

        public string Author { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}

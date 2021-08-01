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

        public string Context { get; set; }

        public TypeBlog TypeBlog { get; set; }

        public string AuthorId { get; set; }

        public FitForLifeUser Author { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}

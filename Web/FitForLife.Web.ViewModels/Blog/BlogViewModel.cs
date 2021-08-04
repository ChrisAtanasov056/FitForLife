namespace FitForLife.Web.ViewModels.Blog
{
    using FitForLife.Data.Models;
    using FitForLife.Data.Models.Enums;
    using FitForLife.Services.Mapping;
    using System;

    public class BlogViewModel: IMapFrom<Blog>
    {
        public string Id { get; init; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ImageUrl { get; set; }

        public string Context { get; set; }

        public TypeBlog TypeBlog { get; set; }

        public string Author { get; set; }
    }
}

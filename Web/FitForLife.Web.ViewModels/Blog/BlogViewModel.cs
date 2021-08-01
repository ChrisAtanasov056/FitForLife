namespace FitForLife.Web.ViewModels.Blog
{
    using FitForLife.Data.Models;
    using FitForLife.Data.Models.Enums;
    using FitForLife.Services.Mapping;

    public class BlogViewModel: IMapFrom<Blog>
    {
        public string Id { get; init; }

        public string Name { get; set; }

        public string Context { get; set; }

        public TypeBlog TypeBlog { get; set; }

        public FitForLifeUser Author { get; set; }
    }
}

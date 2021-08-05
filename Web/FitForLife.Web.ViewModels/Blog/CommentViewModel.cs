namespace FitForLife.Web.ViewModels.Blog
{
    using FitForLife.Data.Models;
    using FitForLife.Services.Mapping;
    using System;

    public class CommentViewModel: IMapFrom<Comment>
    {
        public string Author { get; set; }

        public string Context { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

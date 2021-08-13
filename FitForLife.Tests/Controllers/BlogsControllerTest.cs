namespace FitForLife.Tests.Controllers
{
    using FitForLife.Controllers;
    using FitForLife.Data;
    using FitForLife.Data.Models;
    using FitForLife.Web.ViewModels.Blog;
    using FluentAssertions;
    using MyTested.AspNetCore.Mvc;
    using NLipsum.Core;
    using Xunit;

    using static Data.Blogs;

    public class BlogsControllerTest
    {
        [Fact]
        public void IndexShouldReturnViewWithCorrectModelAndData()
           => MyMvc
               .Pipeline()
               .ShouldMap("/Blogs")
               .To<BlogsController>(c => c.Index())
               .Which(controller => controller
                   .WithData(TwoBlogs))
               .ShouldReturn()
               .View(view => view
                   .WithModelOfType<AllBlogViewModel>()
                   .Passing(m => m.Blogs.Should().HaveCount(2)));
        

    }
}

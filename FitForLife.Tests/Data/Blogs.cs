namespace FitForLife.Tests.Data
{
    using FitForLife.Data.Models;
    using NLipsum.Core;
    using System.Collections.Generic;
    using System.Linq;

    public class Blogs
    {
        public static List<Blog> TwoBlogs
            => Enumerable.Range(0, 2).Select(i => new Blog
            {
                Name = new Word().ToString(),
                Context = new Sentence().ToString(),
            }).ToList();
        public static Blog SingleBlog
            => new()
            {
                Author = new Word().ToString(),
                Context = new Sentence().ToString(),
            };


    }
}

namespace FitForLife.Tests.Services
{
    using FitForLife.Data.Models;
    using FitForLife.Data.Models.Enums;
    using FitForLife.Services.Data;
    using FitForLife.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;
    using NLipsum.Core;

    public class BlogsServiceTests : BaseServiceTests
    {
        private IBlogService Service => this.ServiceProvider.GetRequiredService<IBlogService>();
        
        [Fact]
        public async Task GetCommentsAllAsyncShoudWorkCorrectly()
        {
            var blog = await this.CreateBlogPostAsync();
            await this.CreateCommentAsync(blog);


            var AllcomentsCount = await this.Service.GetCommentsAllAsync<TestCommentModel>(blog.Id);

            Assert.Single(AllcomentsCount);
        }

        //Task<List<T>> GetCommentsAllAsync<T>(string blogId);
        [Fact]
        public async Task AddingCommentToPostShouldAddCorrectly()
        {
            var blog = await this.CreateBlogPostAsync();
            var comment = await CreateCommentAsync(blog);

            var commentCount = await this.DbContext.Comments.CountAsync();
            var resultBlog = await this.DbContext.Blogs.FirstOrDefaultAsync(x => x.Id == blog.Id);

            Assert.Equal(1, commentCount);
            Assert.Equal(1, resultBlog.Comments.Count);
        }

       

        [Fact]
        public async Task GetAllAsync()
        {
            await this.CreateBlogPostAsync();
             await this.CreateBlogPostAsync();
            await this.CreateBlogPostAsync();

            var returnBlog = await this.Service.GetAllAsync<TestBlogModel>();

            Assert.Equal(3, returnBlog.Count);

        }
        [Fact]
        public async Task GetByIdAsync()
        {
            var blog = await this.CreateBlogPostAsync();


            var returnBlog = await this.Service.GetByIdAsync<TestBlogModel>(blog.Id);

            Assert.Equal(blog.Id ,returnBlog.Id);
            Assert.Equal(blog.Name ,returnBlog.Name);

        }
        [Fact]
        public async Task AddAsyncShouldAddCorrectly()
        {
            await this.CreateBlogPostAsync();

            var name = new Sentence().ToString();
            var content = new Paragraph().ToString();
            var author = new Word().ToString();
            var imageUrl = new Word().ToString();
            var typeBLog = TypeBlog.Diet;

            await this.Service.AddAsync(name, content, author, imageUrl, typeBLog);

            var blogPostsCount = await this.DbContext.Blogs.CountAsync();
            Assert.Equal(2, blogPostsCount);
        }
        [Fact]
        public async Task DeleteAsyncShouldDeleteCorrectly()
        {
            var blogPost = await this.CreateBlogPostAsync();

            await this.Service.DeleteAsync(blogPost.Id);

            var blogsCount = this.DbContext.Blogs.Where(x => !x.IsDeleted).ToList().Count();
            var deletedBlogPost = await this.DbContext.Blogs.FirstOrDefaultAsync(x => x.Id == blogPost.Id);
            Assert.Equal(0, blogsCount);
            Assert.Null(deletedBlogPost);
        }
        private async Task<Blog> CreateBlogPostAsync()
        {
            var blog = new Blog
            {
                Name = "Test Title",
                Context = new Paragraph().ToString(),
                Author = new Word().ToString(),
                ImageUrl = new Word().ToString(),
                TypeBlog = TypeBlog.Lifestyle,
            };

            await this.DbContext.Blogs.AddAsync(blog);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Blog>(blog).State = EntityState.Detached;
            return blog;
        }
        private async Task<Comment> CreateCommentAsync(Blog blog)
        {
            var comment = new Comment()
            {
                Context = new Sentence().ToString(),
                Author = new Word().ToString(),
                BlogId = blog.Id,
            };

            await this.Service.AddingCommentToPost(comment.BlogId, comment.Author, comment.Context);
            await this.DbContext.SaveChangesAsync();
            return comment;
        }
        public class TestBlogModel : IMapFrom<Blog>
        {
            public string Id { get; set; }

            public string Name { get; set; }
        }
        public class TestCommentModel : IMapFrom<Comment>
        {
            public string Id { get; set; }

            public string Author { get; set; }
        }
    }
}

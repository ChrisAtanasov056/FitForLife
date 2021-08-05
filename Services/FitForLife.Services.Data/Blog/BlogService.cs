namespace FitForLife.Services.Data.Blog
{
    using FitForLife.Data.Common.Repositories;
    using FitForLife.Data.Models;
    using FitForLife.Data.Models.Enums;
    using FitForLife.Services.Mapping;
    using FitForLife.Web.ViewModels.Blog;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BlogService : IBlogService
    {
        private readonly IDeletableEntityRepository<Blog> blogRepository;
        private readonly IDeletableEntityRepository<Comment> commentRepository;

        public BlogService(IDeletableEntityRepository<Blog> blogRepository, IDeletableEntityRepository<Comment> commentRepository)
        {
            this.blogRepository = blogRepository;
            this.commentRepository = commentRepository;
        }

        public async Task AddAsync(string name, string context, string author , string imageUrl, TypeBlog type)
        {
            await this.blogRepository.AddAsync(new Blog
            {
                Name = name,
                Context = context,
                Author = author,
                TypeBlog = type,
                ImageUrl = imageUrl
            });
            await this.blogRepository.SaveChangesAsync();
        }

        public async Task AddingCommentToPost(string blogId, string author, string context)
        {
            var blog = await this.blogRepository
                .All()
                .Where(x => x.Id == blogId)
                .FirstOrDefaultAsync();
            var newComment = new Comment
            {
                Context = context,
                Author = author,
            };
            blog.Comments.Add(newComment);
            await blogRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var blog = await this.blogRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.blogRepository.Delete(blog);
            await this.blogRepository.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync<T>(int? count = null)
        {
            IQueryable<Blog> query =
                this.blogRepository
                .All()
                .OrderBy(x => x.Id);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return await query.To<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(string id)
        {
            var blog = await this.blogRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
            return blog;
        }

        public async Task<List<T>> GetCommentsAllAsync<T>(string blogId)
        {
            IQueryable<Comment> query =
                this.commentRepository
                .All()
                .Where(x=>x.BlogId == blogId)
                .OrderByDescending(x => x.CreatedOn);
            return await query.To<T>().ToListAsync();
        }
    }
}

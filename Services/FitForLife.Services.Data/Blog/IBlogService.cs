namespace FitForLife.Services.Data
{
    using FitForLife.Data.Models;
    using FitForLife.Data.Models.Enums;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBlogService
    {
        Task<List<T>> GetAllAsync<T>(int? count = null);

        Task<T> GetByIdAsync<T>(string id);

        Task AddingCommentToPost(string blogId, string author, string context);

        Task<List<T>> GetCommentsAllAsync<T>(string blogId);

        Task AddAsync(string name, string context, string author, string imageUrl, TypeBlog type);

        Task DeleteAsync(string id);
    }
}

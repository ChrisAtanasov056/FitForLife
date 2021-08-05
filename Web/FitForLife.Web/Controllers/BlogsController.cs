namespace FitForLife.Controllers
{
    using FitForLife.Services.Data;
    using FitForLife.Web.ViewModels.Blog;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Linq;
    using System.Threading.Tasks;

    public class BlogsController : Controller
    {
        private readonly IBlogService blogService;

        public BlogsController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new AllBlogViewModel
            {
                Blogs = await this.blogService.GetAllAsync<BlogViewModel>()
            };
            return this.View(viewModel);

        }
        public async Task<IActionResult> Details(string Id)
        {
            var viewModel = await this.blogService.GetByIdAsync<BlogViewModel>(Id);
            return this.View(viewModel);

        }
        [HttpPost]
        public async Task<IActionResult> AddComment(BlogViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.blogService.AddingCommentToPost(model.CommentInputModel.BlogId ,model.CommentInputModel.Author, model.CommentInputModel.Context);
            return Redirect(Url.RouteUrl("Index") +"/Blogs"+"/Details/" + model.Id);
        }
    }
}

namespace FitForLife.Controllers
{
    using FitForLife.Services.Data;
    using FitForLife.Web.ViewModels.Blog;
    using Microsoft.AspNetCore.Mvc;
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

            if (this.User.Identity.IsAuthenticated)
            {
                return this.View(viewModel);
            }
            return this.View(viewModel);

        }
    }
}

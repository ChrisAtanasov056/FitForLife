using FitForLife.Data.Models.Enums;
using FitForLife.Services.Data;
using FitForLife.Web.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitForLife.Areas.Administration.Controllers
{

    public class BlogsController : AdministrationController
    {
        private readonly IBlogService blogService;

        public BlogsController(IBlogService blockService)
        {
            this.blogService = blockService;
        }
        public async Task<IActionResult> Index()
        {
            var viewModel = new AllBlogViewModel
            {
                Blogs = await this.blogService.GetAllAsync<BlogViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult AddBlog()
        {

            var types = new List<TypeBlog>();
            foreach (var item in Enum.GetValues(typeof(TypeBlog)))
            {
                types.Add((TypeBlog)item);
            }
            this.ViewData["Blog Types"] = new SelectList(types);
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBlog(BlogViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.blogService.AddAsync(model.Name, model.Context, model.Author, model.ImageUrl,model.TypeBlog);
            return this.RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteBlog(string Id)
        {
            await this.blogService.DeleteAsync(Id);

            return this.RedirectToAction("Index");
        }
    }
}

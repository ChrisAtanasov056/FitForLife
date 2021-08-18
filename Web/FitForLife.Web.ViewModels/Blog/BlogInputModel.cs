using FitForLife.Data.Models;
using FitForLife.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FitForLife.Web.ViewModels.Blog
{
    public class BlogInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Required]
        public string Context { get; set; }

        public TypeBlog TypeBlog { get; set; }
        
        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Author { get; set; }
    }
}

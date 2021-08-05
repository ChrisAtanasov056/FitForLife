using System.ComponentModel.DataAnnotations;

namespace FitForLife.Web.ViewModels.Blog
{
    public class CommentInputModel
    {
        public string BlogId { get; set; }
        [Required]
        [MaxLength(40)]
        public string Author { get; set; }
        
        [Required]
        public string Context { get; set; }

       
    }
}

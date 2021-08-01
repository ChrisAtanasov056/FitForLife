using System.ComponentModel.DataAnnotations;

namespace FitForLife.Web.ViewModels.Classes
{
    public class ClassInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]

        public string Description { get; set; }
        
        [Required]
        public string PictureUrl { get; set; }

    }
}

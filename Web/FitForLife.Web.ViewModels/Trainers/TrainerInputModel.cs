using System.ComponentModel.DataAnnotations;

namespace FitForLife.Web.ViewModels.Trainers
{
    public class TrainerInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }


        public int Age { get; set; }

        public string City { get; set; }

        [Required]
        [Url]
        public string ProfilePictureUrl { get; set; }

        public string Description { get; set; }

        [Required]
        public int ClassId { get; set; }
    }
}

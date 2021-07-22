using FitForLife.Data.Models;
using FitForLife.Services.Mapping;
using System.Collections.Generic;

namespace FitForLife.Web.ViewModels.Trainers
{
    public class TrainerViewModel : IMapFrom<FitForLifeUser>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string Description { get; set; }
    }
}

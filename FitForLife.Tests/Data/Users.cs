
using FitForLife.Data.Models;
using FitForLife.Web.ViewModels.Trainers;
using NLipsum.Core;
using System.Collections.Generic;
using System.Linq;

namespace FitForLife.Tests.Data
{
    public class Users
    {
        public static List<TrainerViewModel> twoTrainers
            => Enumerable.Range(0, 2).Select(i => new TrainerViewModel
            {
                FirstName = new Word().ToString(),
                LastName = new Word().ToString(),
                ProfilePictureUrl = new Sentence().ToString(),
            }).ToList();
    }
}

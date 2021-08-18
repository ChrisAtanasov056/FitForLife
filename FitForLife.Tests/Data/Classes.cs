using FitForLife.Data.Models;
using FitForLife.Web.ViewModels.Classes;
using NLipsum.Core;
using System.Collections.Generic;
using System.Linq;

namespace FitForLife.Tests.Data
{
    public class Classes
    {
        public static List<Class> ThreeClasses
            => Enumerable.Range(0, 3).Select(i => new Class
            {
                Name = new Word().ToString(),
                PictureUrl = new Sentence().ToString(),
                Description = new Paragraph().ToString()
            }).ToList();
    }
}

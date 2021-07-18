using FitForLife.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FitForLife.Data.Seeding.CustomSeeders
{
    public class ClassesSeeder : ISeeder
    {
        public async Task SeedAsync(FitForLifeDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Classes.Any())
            {
                return;
            }
            var classes = new Class[]
            {
                new Class
                {
                    Name = "Bodybuilding",
                    Description = "Bodybuilding, a regimen of exercises designed to enhance the human body's muscular development and promote general health and fitness. As a competitive activity, bodybuilding aims to display in artistic fashion pronounced muscle mass, symmetry, and definition for overall aesthetic effect.",
                    PictureUrl = "https://manofmany.com/wp-content/uploads/2021/02/Bodybuilding-Supplement-Stacks-1200x800.jpg",
                },
                new Class
                {
                    Name = "Kango Jumps",
                    Description = "Kangoo Jump Rebound Shoes are an amazing and safe approach to cardio and core muscle work. It saves your joints and improves your endurance for all fitness activities. It is also a great way to train runners to strengthen and lengthen their stride.",
                    PictureUrl = "https://www.thehealthfarm.be/wp-content/uploads/2019/10/kangoojumps-1024x620.jpg",
                },
                new Class
                {
                    Name = "Pilates",
                    Description = "Pilates is a method of exercise that consists of low-impact flexibility and muscular strength and endurance movements.",
                    PictureUrl = "https://pulsefit.bg/uploads/cache/original/public/uploads/media-manager/app-modules-activities-models-activity/7/1413/pilates.jpg",
                },
                new Class
                {
                    Name = "Zumba",
                    Description = "Zumba is a fitness program that combines Latin and international music with dance moves.",
                    PictureUrl = "https://www.verywellfit.com/thmb/WtaRzGOCbJdVYFlWr_7VOfwn_Ow=/3000x2002/filters:no_upscale():max_bytes(150000):strip_icc()/zumba-fatcamera-c9d4ee824a0f4fda883484f878abc8ae.jpg",
                },
                new Class
                {
                    Name = "Yoga",
                    Description = "A relaxing form of exercise that was developed in India and involves assuming and holding postures that stretch the limbs and muscles, doing breathing exercises, and using meditation techniques to calm the mind. Yoga appears to have benefits for increasing physical flexibility and reducing internal feelings of stress. Yoga may be recommended as an alternative or complementary health-promoting practice.",
                    PictureUrl = "https://www.verywellfit.com/thmb/uzykMmNobXgHB9QKd3VjtfYhYIE=/3435x2576/smart/filters:no_upscale()/yoga-class-stretching-640630209-57f3b8263df78c690f28580c.jpg",
                },
            };
            foreach (var clas in classes)
            {
                await dbContext.AddAsync(clas);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

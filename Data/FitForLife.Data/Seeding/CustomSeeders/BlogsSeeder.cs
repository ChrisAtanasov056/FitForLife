namespace FitForLife.Data.Seeding.CustomSeeders
{
    using FitForLife.Data.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class BlogsSeeder : ISeeder
    {
        public async Task SeedAsync(FitForLifeDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Blogs.Any())
            {
                return;
            }
            var blogs = new Blog[]
           {
               new Blog
               {
                   Name = "THESE 3 SPRINT WORKOUTS WILL HELP BLAST FAT AND BUILD ATHLETIC POWER",
                   Context = "Sprinting isn’t just for Usain Bolt-type Olympic athletes, the same way jumping rope isn’t solely for Floyd Mayweather’s pre-fight warmup; Running all-out is for anyone looking to build overall conditioning. Sprinting can help boost lung power, increase speed, accelerate fat loss, and increasing lean muscle mass.If you’re not the biggest cardio fan, here’s some news you can use: Interval training has shown to outperform steady - state cardio when it comes to reducing body fat and burning calories.Sure, all exercises burn calories, and there are many benefits to endurance running, but sprinting comes in strong as it burns more calories and fat both during and after your workout, giving you more bang for your buck!Linda Solomon, RRCA running coach and marathon runner out of Brockton, MA, says sprinting is perfect for those looking to speed up their running pace as well as fat loss. “Sprinting will increase your speed and endurance, but if your goal is weight loss, sprinting will build lean muscle mass, which will help you meet your weight-loss goal while boosting metabolism.”FOR MAX RESULTS, LEARN PROPER SPRINT FORMWhen it comes to sprinting, form matters. “Make sure your arms are by your side in a relaxed position and bring knees up when in motion,” says Solomon. This may not come easy at first, especially if you’re not a runner to begin with.Solomon offers one trick she uses that can help beginner sprinters master their form. “Running up hills is a great way to learn how to sprint correctly because it helps the runner focus on form,” she adds. If you don’t have hills nearby, you can also use a treadmill that elevates.So, if you’re looking to give your fitness level a boost, try these three HIIT sprinting workouts(warm up first) for you to try this summer at your local track.",
                   TypeBlog = Models.Enums.TypeBlog.Exicise,
               },
               new Blog
               {
                   Name = "10 THINGS YOU NEED TO KNOW WHEN STARTING A NEW DIET",
                   Context = "Getting started on a diet is the easy part, the hard part is sticking to it and getting results.Here are ten tips to make sure you get the most out of your meal plan by knowing what to expect and how to set yourself up for success.1. Mindset is EverythingHow many times have you gone into a new diet, or any change for that matter, with high expectations only to crash and burn within weeks ? This is way more common than you realize.So many people go into a new diet with an all - or - nothing mindset.Not only does this set you up for disappointment, but it makes the change that much harder and more uncomfortable from the get-go.You don’t have to give up everything or overhaul your entire life to get results.Small changes that you can stick to tend to be the best approach.Plus they set you up for success since they tend to be easier.Start with one or two small goals that you think you need to work on and aim to stick to those for two to three weeks, with the intention of making them a habit.Then once you’ve mastered your small goals, add some more.Or if you’re still struggling, try a different goal, trying different habits on until something clicks.2. Systems Make it EasierOne of the best things you can do for your long term health and fitness goals is to build systems.Systems are routines built into your everyday life, helping you remove obstacles and build habits.And the more seamless you can make your goals, the easier they are to stick to and the faster results come.Want to get better at hitting the gym every morning ? Pick out your gym clothes the night before and lay them beside your bed.Want to stop eating out for lunch every day ? Set a time to meal prep healthy options every week or opt for a meal delivery service that does the hard work for you.",
                   TypeBlog = Models.Enums.TypeBlog.Diet
               }
           };
            foreach (var blog in blogs)
            {
                await dbContext.AddAsync(blog);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

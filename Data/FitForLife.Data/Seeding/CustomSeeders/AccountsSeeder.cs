namespace FitForLife.Data.Seeding.CustomSeeders
{
    using System;
    using System.Threading.Tasks;
    using System.Linq;
    
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    
    using FitForLife.Data.Models;
    using FitForLife.Common;
    

    public class AccountsSeeder : ISeeder
    {
        public async Task SeedAsync(FitForLifeDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<FitForLifeUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<FitForLifeRole>>();

            // Create Admin
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountsSeeding.AdminEmail,
                "Kristiyan", "Atanasov",
                null,
                null,
            GlobalConstants.AdministratorRoleName);
                
            // Create Bodybuiling Trainer
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountsSeeding.TrainerEmail,
                "Ivan", "Ivanov",
                dbContext.Classes.FirstOrDefault(c => c.Name == "Bodybuilding"),
                GlobalConstants.AccountsSeeding.BodybuilingTrainerPic,
                GlobalConstants.AccountsSeeding.BodybuilingDescription,
                GlobalConstants.TrainerRoleName);
            // Create Kango Trainer
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountsSeeding.KangoEmail,
                "Jenny", "Dryanovska",
                dbContext.Classes.FirstOrDefault(c => c.Name == "Kango Jumps"),
                GlobalConstants.AccountsSeeding.KangoTrainerPic,
                GlobalConstants.AccountsSeeding.KangoDescription,
                GlobalConstants.TrainerRoleName);
            // Create Zumba Trainer
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountsSeeding.ZumbaEmail,
                "Petya", "Marinova",
                dbContext.Classes.FirstOrDefault(c => c.Name == "Zumba"),
                GlobalConstants.AccountsSeeding.ZumbaTrainerPic,
                GlobalConstants.AccountsSeeding.ZumbaDescription,
                GlobalConstants.TrainerRoleName);
            // Create Pilates Trainer
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountsSeeding.PilatesEmail,
                "Maria", "Petrova",
                dbContext.Classes.FirstOrDefault(c => c.Name == "Pilates"),
                GlobalConstants.AccountsSeeding.PilatesTrainerPic,
                GlobalConstants.AccountsSeeding.PitalatesDescription,
                GlobalConstants.TrainerRoleName
                );
            // Create Pilates Trainer
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountsSeeding.YogaEmail,
                "Alis", "Nikolova",
                dbContext.Classes.FirstOrDefault(c => c.Name == "Yoga"),
                GlobalConstants.AccountsSeeding.YogaTrainerPic,
                GlobalConstants.AccountsSeeding.YogaDescription,
                GlobalConstants.TrainerRoleName
                );

        }
        private static async Task CreateUser(
            UserManager<FitForLifeUser> userManager, RoleManager<FitForLifeRole> roleManager, string email, string FirstName, string LastName, Class @class, string picUrl, string description ,string roleName = null)
        {
            var user = new FitForLifeUser
            {
                UserName = email,
                Email = email,
                ProfilePictureUrl = picUrl,
                FirstName = FirstName,
                LastName = LastName,
                Class = @class,
                Description = description
            };


            var password = GlobalConstants.AccountsSeeding.Password;

            if (roleName != null)
            {
                var role = await roleManager.FindByNameAsync(roleName);

                if (!userManager.Users.Any(x => x.UserName == user.UserName))
                {
                    var result = await userManager.CreateAsync(user, password);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, roleName);
                    }
                }
            }
            else
            {
                if (userManager.Users.Any(x => x.Roles.Count() == 0))
                {
                    var result = await userManager.CreateAsync(user, password);
                }
            }
        }
    }
}

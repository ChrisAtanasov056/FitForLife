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
            GlobalConstants.AdministratorRoleName);
                
            // Create Trainer
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountsSeeding.TrainerEmail,
                "Ivan", "Ivanov",
                GlobalConstants.TrainerRoleName);
            // Create Kango Trainer
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountsSeeding.KangoEmail,
                "Jenny", "Dryanovska",
                GlobalConstants.TrainerRoleName);
            // Create Zumba Trainer
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountsSeeding.ZumbaEmail,
                "Petya", "Marinova",
                GlobalConstants.TrainerRoleName);
            // Create Pilates Trainer
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountsSeeding.PilatesEmail,
                "Petya", "Marinova",
                GlobalConstants.TrainerRoleName
                );

        }
        private static async Task CreateUser(
            UserManager<FitForLifeUser> userManager, RoleManager<FitForLifeRole> roleManager, string email, string FirstName, string LastName,string roleName = null)
        {
            var user = new FitForLifeUser
            {
                UserName = email,
                Email = email,
                ProfilePictureUrl = "https://i1.wp.com/norrismgmt.com/wp-content/uploads/2020/05/24-248253_user-profile-default-image-png-clipart-png-download.png",
                FirstName = FirstName,
                LastName = LastName
            };

            var password = GlobalConstants.AccountsSeeding.Password;

            if (roleName != null)
            {
                var role = await roleManager.FindByNameAsync(roleName);

                if (userManager.Users.Any(x => x.UserName != user.UserName))
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

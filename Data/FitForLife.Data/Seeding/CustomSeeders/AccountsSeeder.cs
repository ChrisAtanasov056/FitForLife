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
                GlobalConstants.AdministratorRoleName);
           
            // Create Trainer
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountsSeeding.TrainerEmail,
                GlobalConstants.TrainerRoleName);
            // Create Kango Trainer
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountsSeeding.KangoEmail,
                GlobalConstants.TrainerRoleName);
            // Create Zumba Trainer
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountsSeeding.ZumbaEmail,
                GlobalConstants.TrainerRoleName);
            // Create Pilates Trainer
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountsSeeding.PilatesEmail,
                GlobalConstants.TrainerRoleName);

        }
        private static async Task CreateUser(
            UserManager<FitForLifeUser> userManager, RoleManager<FitForLifeRole> roleManager, string email, string roleName = null)
        {
            var user = new FitForLifeUser
            {
                UserName = email,
                Email = email,
            };

            var password = GlobalConstants.AccountsSeeding.Password;

            if (roleName != null)
            {
                var role = await roleManager.FindByNameAsync(roleName);

                if (!userManager.Users.Any(x => x.Roles.Any(x => x.RoleId == role.Id)))
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
                if (!userManager.Users.Any(x => x.Roles.Count() == 0))
                {
                    var result = await userManager.CreateAsync(user, password);
                }
            }
        }
    }
}

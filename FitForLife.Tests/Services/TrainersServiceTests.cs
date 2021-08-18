namespace FitForLife.Tests.Services
{
    using FitForLife.Common;
    using FitForLife.Data.Models;
    using FitForLife.Services.Data.Trainers;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using NLipsum.Core;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class TrainersServiceTests : BaseServiceTests
    {
        //private ITrainersService Service => this.ServiceProvider.GetRequiredService<ITrainersService>();
        //private readonly RoleManager<FitForLifeRole> roleManager;
        //private readonly UserManager<FitForLifeUser> userManager;
        
        //public TrainersServiceTests(RoleManager<FitForLifeRole> roleManager, UserManager<FitForLifeUser> userManager)
        //{
        //    this.roleManager = roleManager;
        //    this.userManager = userManager;
            
        //}
        ////Task<List<T>> GetAllTrainersAsync<T>(int? count = null);

        ////Task<List<ClientTrainer>> GetAllClients<T>(string id);

        ////Task<T> GetTrainerById<T>(string id);

        ////Task AddUserToTrainer(string trainerId, string clientId);

        ////Task AddAsync(string firstName, string LastName, string imageUrl, string email, string password, int age, string city, string description, int classId);
        //[Fact]
        //public async Task AddAsyncShouldAddCorrectly()
        //{
        //    var trainer = await this.CreateTrainerAsync();

        //    var trainers = await this.DbContext.Users.Where(x => x.Roles.Any(y => y.RoleId == trainer.Id)).CountAsync();

        //    Assert.Equal(1, trainers);
        //}

        ////Task DeleteAsync(string id);
        //private async Task<FitForLifeUser> CreateTrainerAsync()
        //{

        //    var trainer = new FitForLifeUser
        //    {
        //        FirstName = new Word().ToString(),
        //        LastName = new Word().ToString(),
        //        Email = "test@test.com",
        //        UserName = "test@test.com",
        //    };
        //    var pass = "123456";
        //    if (trainer != null)
        //    {
        //        await roleManager.CreateAsync(new FitForLifeRole(GlobalConstants.TrainerRoleName));
        //        await this.DbContext.SaveChangesAsync();
        //        var role = await roleManager.FindByNameAsync(GlobalConstants.TrainerRoleName);
        //        var result = await userManager.CreateAsync(trainer, pass);

        //        if (result.Succeeded)
        //        {
        //            await userManager.AddToRoleAsync(trainer, role.Name);
        //        }
        //    }

        //    await this.DbContext.Users.AddAsync(trainer);
        //    await this.DbContext.SaveChangesAsync();
        //    this.DbContext.Entry<FitForLifeUser>(trainer).State = EntityState.Detached;
        //    return trainer;
        //}
    }
}

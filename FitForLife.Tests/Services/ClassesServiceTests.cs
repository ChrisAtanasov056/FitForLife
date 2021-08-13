
using FitForLife.Data.Models;
using FitForLife.Services.Data.Classes;
using FitForLife.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLipsum.Core;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FitForLife.Tests.Services
{
    public class ClassesServiceTests : BaseServiceTests
    {
        private IClassesService Service => this.ServiceProvider.GetRequiredService<IClassesService>();
        //Task<List<T>> GetAllAsync<T>(int? count = null);
        [Fact]
        public async Task GetAllAsyncShoudWorkCorrectly()
        {
            await this.CreateClassAsync();
            await this.CreateClassAsync();
            await this.CreateClassAsync();

            var testClasses = await this.Service.GetAllAsync<TestClassModel>();

            Assert.Equal(3, testClasses.Count);

        }
        //Task<T> GetByIdAsync<T>(int id);
        [Fact]
        public async Task GetByIdAsync()
        {
            var @class = await this.CreateClassAsync();


            var returnClass = await this.Service.GetByIdAsync<TestClassModel>(@class.Id);

            Assert.Equal(@class.Id, returnClass.Id);
            Assert.Equal(@class.Name, returnClass.Name);

        }
        //Task AddAsync(string name, string description, string imageUrl);
        [Fact]
        public async Task AddAsyncShouldAddCorrectly()
        {
            await this.CreateClassAsync();

            var cardCount = await this.DbContext.Classes.CountAsync();

            Assert.Equal(1, cardCount);
        }

        //Task DeleteAsync(int id);
        [Fact]
        public async Task DeleteAsyncShouldDeleteCorrectly()
        {
            var @class = await this.CreateClassAsync();

            await this.Service.DeleteAsync(@class.Id);

            var classCount = this.DbContext.Classes.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedClass = await this.DbContext.Classes.FirstOrDefaultAsync(x => x.Id == @class.Id);
            Assert.Equal(0, classCount);
            Assert.Null(deletedClass);
        }

        private async Task<Class> CreateClassAsync()
        {
            var @class = new Class
            {
                Name = "Test Title",
                PictureUrl = new Paragraph().ToString(),
                Description = new Sentence().ToString(),
            };

            await this.DbContext.Classes.AddAsync(@class);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Class>(@class).State = EntityState.Detached;
            return @class;
        }
        public class TestClassModel : IMapFrom<Class>
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}

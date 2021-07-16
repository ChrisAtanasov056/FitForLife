namespace FitForLife.Services.Data.Classes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FitForLife.Data.Common.Repositories;
    using FitForLife.Data.Models;
    using FitForLife.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class ClassesService : IClassesService
    {
        private readonly IDeletableEntityRepository<Class> classesRepository;

        public ClassesService(IDeletableEntityRepository<Class> classesRepository)
        {
            this.classesRepository = classesRepository;
        }

        public async Task AddAsync(string name, string description, string pictureUrl)
        {
            await this.classesRepository.AddAsync(new Class
            {
                Name = name,
                Description = description,
                PictureUrl = pictureUrl,
            });
            await this.classesRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var classes = await this.classesRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.classesRepository.Delete(classes);
            await this.classesRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(int? count = null)
        {
            IQueryable<Class> query =
                this.classesRepository
                .All()
                .OrderBy(x => x.Id);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return await query.To<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var classes = await this.classesRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return classes;
        }

    }
}

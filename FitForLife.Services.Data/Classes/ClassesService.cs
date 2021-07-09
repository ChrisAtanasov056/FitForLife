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

        public Task AddAsync(string name, string description, string imageUrl)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
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

        public Task<T> GetByIdAsync<T>(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

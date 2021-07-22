namespace FitForLife.Services.Data.Trainers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITrainersService
    {
        public Task<List<T>> GetAllTrainersAsync<T>();
    }
}

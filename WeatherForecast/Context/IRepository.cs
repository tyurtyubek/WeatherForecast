using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecast.Context
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> Get();
        void Add(T newCity);
        bool Save();
        Task<T> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        void EditCity(SavedCity city);
    }
}

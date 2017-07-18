using System;
using System.Collections.Generic;
using WeatherForecast.Models;

namespace WeatherForecast.Context
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> Get();
        void Add(T newCity);
        bool Save();
        T GetById(int id);
        void Delete(int id);
        void EditCity(SavedCity city);
    }
}

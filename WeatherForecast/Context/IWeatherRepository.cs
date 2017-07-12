using System;
using System.Collections.Generic;
using WeatherForecast.Models;

namespace WeatherForecast.Context
{
    public interface IWeatherRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetCities();
        void AddCity(SavedCity newCity);
        bool SaveAll();
        SavedCity GetById(int id);
        void DeleteCity(int id);
    }
}

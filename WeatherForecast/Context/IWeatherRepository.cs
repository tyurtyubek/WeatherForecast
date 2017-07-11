using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecast.Context
{
    public interface IWeatherRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetCities();
        void AddCity(SavedCity newCity);
        bool SaveAll();
        void DeleteCity(string cityName);
        void UpdateCity(T city);
    }
}

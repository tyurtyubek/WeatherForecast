using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecast.Context
{
    public interface ICityLogRepository
    {
        IEnumerable<CityLog> GetCitiesLog();
        void AddLog(CityLog newCity);
        void Save();
        Task DeleteCityAsync(int id);
        void DeleteAll();
    }
}

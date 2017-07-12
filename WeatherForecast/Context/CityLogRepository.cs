using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecast.Context
{
    public class CityLogRepository : ICityLogRepository
    {
        TheWeatherContext _contextCityLog;
        public CityLogRepository()
        {
            _contextCityLog = new TheWeatherContext();
        }
        public void AddLog(CityLog newCity)
        {
            _contextCityLog.CitiesLogs.Add(newCity);
        }

        public void DeleteCity(int id)
        {
            CityLog deleteCity = _contextCityLog.CitiesLogs.Find(id);
            if (deleteCity != null) _contextCityLog.CitiesLogs.Remove(deleteCity);
            Save();
        }

        public IEnumerable<CityLog> GetCitiesLog()
        {
            try
            {
                return _contextCityLog.CitiesLogs;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void DeleteAll()
        {
            foreach (var element in _contextCityLog.CitiesLogs)
            {
                _contextCityLog.CitiesLogs.Remove(element);
            }
            _contextCityLog.SaveChanges();
        }
        public void Save()
        {
            _contextCityLog.SaveChanges();
        }
    }
}

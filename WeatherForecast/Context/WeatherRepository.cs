﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecast.Context
{
    public class WeatherRepository : IWeatherRepository<SavedCity>
    {
        TheWeatherContext _contextdb;
        public WeatherRepository()
        {
            _contextdb = new TheWeatherContext();
        }

        public void AddCity(SavedCity newCity)
        {
            _contextdb.Cities.Add(newCity);
        }

        public void DeleteCity(string cityName)
        {
            SavedCity deleteCity = _contextdb.Cities.Find(cityName);
            if (deleteCity != null) _contextdb.Cities.Remove(deleteCity);
        }

        public IEnumerable<SavedCity> GetCities()
        {
            try
            {
                return _contextdb.Cities;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool SaveAll()
        {
            return _contextdb.SaveChanges() > 0;
        }

        public void UpdateCity(SavedCity city)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _contextdb.Dispose();
                }
                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~WeatherRepository() {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}

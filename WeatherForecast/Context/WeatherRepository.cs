using System;
using System.Collections.Generic;
using WeatherForecast.Models;

namespace WeatherForecast.Context
{
    public class WeatherRepository : IRepository<SavedCity>
    {
        TheWeatherContext _contextdb;
        public WeatherRepository()
        {
            _contextdb = new TheWeatherContext();
        }

        public void Add(SavedCity newCity)
        {
            _contextdb.Cities.Add(newCity);
        }

        public void Delete(int id)
        {
            SavedCity deleteCity = _contextdb.Cities.Find(id);
            if (deleteCity != null) _contextdb.Cities.Remove(deleteCity);
            Save();
        }

        public IEnumerable<SavedCity> Get()
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

        public bool Save()
        {
            return _contextdb.SaveChanges() > 0;
        }

        public SavedCity GetById(int id)
        {
            return _contextdb.Cities.Find(id);
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

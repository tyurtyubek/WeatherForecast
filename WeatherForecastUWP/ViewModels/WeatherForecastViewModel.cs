using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherForecastUWP.Models;
using WeatherForecastUWP.Services;

namespace WeatherForecastUWP.ViewModels
{
    public class WeatherForecastViewModel : ViewModelBase
    {
        private WeatherForecastService _service;
        public List<string> SavedCities { get; private set; }
        private INavigationService _navigationService;
        public ICommand SearchWeather { get; set; }

        public WeatherForecastViewModel(INavigationService navigationService)
        {
            _service = new WeatherForecastService();
            _navigationService = navigationService;
            SearchWeather = new RelayCommand(GetWeatherForecast);
            CityName = "";
            Days = "1";
            GetSavedCities();
        }

        private async void GetSavedCities()
        {
            SavedCities = new List<string>();
            var savedcities = (ICollection)await _service.GetSavedCities();
            foreach (SavedCity city in savedcities)
            {
                SavedCities.Add(city.CityName);
            }
        }

        private string _cityName;
        public string CityName
        {
            get => _cityName;
            set
            {
                _cityName = value;
                RaisePropertyChanged(() => CityName);
            }
        }

        private int _days;
        public string Days
        {
            get { return _days.ToString(); }
            set { _days = Convert.ToInt32(value); }
        }

        private RootObject _weatherforecast;
        public RootObject WeatherForecast
        {
            get { return _weatherforecast; }
            set
            {
                _weatherforecast = value;
                RaisePropertyChanged(() => WeatherForecast);
            }
        }

        private async void GetWeatherForecast()
        {
            WeatherForecast = await _service.GetWeatherForecast(_cityName, _days);
            Result = $"Weather forecast for {WeatherForecast.list.Count} days for {WeatherForecast.city.name}";
        }

        private string _result;
        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                RaisePropertyChanged(() => Result);
            }
        }
    }
}

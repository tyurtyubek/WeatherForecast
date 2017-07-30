using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections;
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
        private INavigationService _navigationService;
        public ObservableCollection<RootObject> _weather { get; set; }
        public ICommand SearchWeather { get; set; }

        public WeatherForecastViewModel(INavigationService navigationService)
        {
            _service = new WeatherForecastService();
            _navigationService = navigationService;
            SearchWeather = new RelayCommand(GetWeatherForecast);
            CityName = "";
            Days = "";
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

        private async void GetWeatherForecast()
        {
            var weathers = (ICollection)await _service.GetWeatherForecast(_cityName, _days);
        }

    }
}

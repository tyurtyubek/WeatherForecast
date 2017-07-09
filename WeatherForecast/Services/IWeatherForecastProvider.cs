using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public interface IWeatherForecastProvider
    {
        RootObject GetWeatherForecastJson(string cityoflist, int days, string cityOwn);
    }
}
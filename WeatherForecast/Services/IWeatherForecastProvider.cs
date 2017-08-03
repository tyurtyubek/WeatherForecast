using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public interface IWeatherForecastProvider
    {
        Task<RootObject> GetWeatherForecastJsonAsync(string cityoflist, int days, string cityOwn);
    }
}
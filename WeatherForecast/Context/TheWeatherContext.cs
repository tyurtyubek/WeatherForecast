using System.Data.Entity;
using WeatherForecast.Models;


namespace WeatherForecast.Context
{
    public class TheWeatherContext : DbContext
    {
        public TheWeatherContext() : base("name = DefaultConnection")
        {
        }
        public DbSet<SavedCity> Cities { get; set; }
        public DbSet<CityLog> CitiesLogs { get; set; }
    }
}

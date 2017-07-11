using System;
using System.Collections.Generic;
using System.Data.Entity;
using WeatherForecast.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeatherForecast.Context
{
    public class TheWeatherContext : DbContext
    {
        public TheWeatherContext():base("name = DefaultConnection") 
        {
        }
        public DbSet<SavedCity> Cities {get; set;}
    }
}

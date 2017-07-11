using System;
using System.Collections.Generic;
using System.Data.Entity;
using WeatherForecast.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeatherForecast.Context
{
    public class CitiesContext : DbContext
    {
        public CitiesContext():base("name = DBConnectionCity") 
        {
        }
        public DbSet<SavedCity> SavedCities {get; set;}
    }
}

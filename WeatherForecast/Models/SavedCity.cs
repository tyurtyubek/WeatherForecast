using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class SavedCity
    {
        public int SavedCityID { get; set; }
        public string CityName { get; set; }
        public DateTime Created { get; set; }
    }
}

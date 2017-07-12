using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherForecast.Models
{
    [Table("CityLog")]
    public class CityLog
    {
        public int Id { get; set; }
        [Required]
        public string CityName { get; set; }
        public DateTime RequestTime { get; set; }
    }
}

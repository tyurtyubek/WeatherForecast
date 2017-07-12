using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherForecast.Models
{
    [Table("Cities")]
    public class SavedCity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CityName { get; set; }
    }
}

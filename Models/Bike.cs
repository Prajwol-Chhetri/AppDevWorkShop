using System.ComponentModel.DataAnnotations;

namespace AppDevWorkShop.Models
{
    public class Bike
    {
        [Key]
        public int Bike_ID { get; set; }
        public string BikeName { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public int Horsepower { get; set; }

    }
}

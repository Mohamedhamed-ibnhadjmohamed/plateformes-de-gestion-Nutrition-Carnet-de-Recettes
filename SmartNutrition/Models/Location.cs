
 using System.ComponentModel.DataAnnotations;
namespace SmartNutrition.Models
{
    public class Location
    {
        [Key] 
        public int Id { get; set; }
        [Required][StringLength(100)]
        public string Name { get; set; }
        public string Building { get; set; }

        //====== Entity Framework Core relationships ======

        // One-to-Many relationship with SensorData: 1 location can have multiple sensors, but each sensor belongs to only 1 location
        public ICollection<SensorData> Sensors { get; set; } = new List<SensorData>();
    }
}

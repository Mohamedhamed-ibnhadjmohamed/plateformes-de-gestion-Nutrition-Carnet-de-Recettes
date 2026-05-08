
 using System.ComponentModel.DataAnnotations;
namespace SmartNutrition.Models
{
    public class Tag
    {
        [Key] 
        public int Id { get; set; }
        [Required][StringLength(30)]
        public string Label { get; set; }


        //===== Entity Framework Core relationships ======

        // Many-to-Many relationship with SensorData: 1 tag can be associated with multiple sensors, and 1 sensor can have multiple tags
        public ICollection<SensorData> Sensors { get; set; } = new List<SensorData>();

    }
}

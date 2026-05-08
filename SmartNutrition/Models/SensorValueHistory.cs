using System.ComponentModel.DataAnnotations;

namespace SmartNutrition.Models
{
    public class SensorValueHistory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double MeasuredValue { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;

        //===== Entity Framework Core relationships ======
        public int SensorDataId { get; set; }  // Foreign key to SensorData (1-to-N): 1 historical value belongs to 1 sensor
        public SensorData SensorData { get; set; } // Navigation property to the related SensorData entity, which allows us to access the sensor that this historical value belongs to
    }
}

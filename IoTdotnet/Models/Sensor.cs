using System.ComponentModel.DataAnnotations;

namespace IoTdotnet.Models
{
    public class Sensor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime lastUpdate { get; set; }
        public int lastValue { get; set; }
        public ICollection<int> values { get; set; }

    }
}

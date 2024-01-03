
namespace IoTdotnet.View
{
    public class SensorVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProjectVM project { get; set; }
        public string Description { get; set; }
        public DateTime lastUpdate { get; set; }
        public int? lastValue { get; set; }
    }
}

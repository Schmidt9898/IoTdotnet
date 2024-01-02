using IoTdotnet.Models;

namespace IoTdotnet.View
{
    public class ProjectVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IotUserVM Owner { get; set; }
    }
}

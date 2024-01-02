using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IoTdotnet.Models
{
    public class Sensor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        //[ForeignKey("Project")]
        //public int ProjectId { get; set; }
        public Project project { get; set; }
        public string Description { get; set; }
        public DateTime lastUpdate { get; set; }
        public int lastValue { get; set; }
        public ICollection<int> values { get; set; }
        public ICollection<IotUser> AllowedUsers { get; set; }

    }
}

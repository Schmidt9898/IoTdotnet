using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IoTdotnet.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IotUser Owner { get; set; }
        public ICollection<Sensor> Sensors { get; set; }
        //public int OwnerId { get; set; }
    }
}

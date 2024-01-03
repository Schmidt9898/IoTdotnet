using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IoTdotnet.Models
{
    public class IotUser : IdentityUser
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int UserId { get; set; }
        //[Required]
        //public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        public string PublicDiscription { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Sensor> SharedSensors { get; set; }
    }
}
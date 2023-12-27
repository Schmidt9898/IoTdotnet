using Microsoft.EntityFrameworkCore;

namespace IoTdotnet.Models
{
    public class SensorsDBContext : DbContext
    {
        public SensorsDBContext(DbContextOptions<SensorsDBContext> configuration) : base(configuration) {}


        public DbSet<Sensor> sensors { get; set; }
        public DbSet<Project> projects { get; set; }


    }
}

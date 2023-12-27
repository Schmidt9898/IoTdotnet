using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databaseTest
{

    public class MyDbContext : DbContext
    {
        public DbSet<TestClass> mylist {  get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server = localhost:12345; Database = postgres; User Id = postgres; Password = mysecretpassword;");
        }

    }

    public class TestClass
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
    }
}

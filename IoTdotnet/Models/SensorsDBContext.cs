using Microsoft.EntityFrameworkCore;

namespace IoTdotnet.Models
{
    public class SensorsDBContext : DbContext
    {
        public SensorsDBContext(DbContextOptions<SensorsDBContext> configuration) : base(configuration) {}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //  One-to-many
            //modelBuilder.Entity<Project>()
            //    .HasOne<IotUser>(r => r.Owner)
            //    .WithMany(rb => rb.Projects)
            //    .HasForeignKey(r => r.OwnerId);
            //modelBuilder.Entity<Sensor>()
            //    .HasOne<Project>(r => r.project)
            //    .WithMany(rb => rb.Sensors)
            //    .HasForeignKey(r => r.ProjectId);

            //  Many-to-many
            //modelBuilder.Entity<Recipe>()
            //    .HasMany<Category>(r => r.Categories)
            //    .WithMany(c => c.Recipes)
            //    .UsingEntity(j => j.ToTable("CategoryRecipe"));

            //modelBuilder.Entity<RecipeBook>().HasData(
            //    new RecipeBook { Id = 1, Name = "My recipe book", Description = "...", RecipesNumber = 2 }
            //    );

            //modelBuilder.Entity<Recipe>().HasData(
            //    new Recipe { Id = 1, Name = "Apple pie", CookTime = 12, Ingredients = "3 Eggs", Method = "Cook", RatingsAvg = 0.5, RecipeBookId = 1 },
            //    new Recipe { Id = 2, Name = "Apple pie2", CookTime = 10, Ingredients = "2 Eggs", Method = "Cook", RatingsAvg = 0.5, RecipeBookId = 1 }
            //    );
        }




        public DbSet<IotUser> users { get; set; } // for this assigment i will not place the users in a different context, but i would otherwise
        public DbSet<Sensor> sensors { get; set; }
        public DbSet<Project> projects { get; set; }


    }
}

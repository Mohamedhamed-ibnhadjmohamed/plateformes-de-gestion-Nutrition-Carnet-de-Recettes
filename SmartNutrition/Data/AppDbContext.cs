using Microsoft.EntityFrameworkCore;
using SmartNutrition.Models;

namespace SmartNutrition.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        // DbSets for each entity, every DbSet represents a table in the database
        public DbSet<SensorData> Sensors { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}

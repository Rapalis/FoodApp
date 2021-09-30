using FoodApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodApp.DataAccess
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions options): base(options) { }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Dish> Dish { get; set; }
        public DbSet<Review> Review { get; set; }
    }
}

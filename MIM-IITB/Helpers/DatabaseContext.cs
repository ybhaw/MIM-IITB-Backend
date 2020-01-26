using Microsoft.EntityFrameworkCore;
using MIM_IITB.Data.Entities;

namespace MIM_IITB.Helpers
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<Intake> Intakes { get; set; }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AuthUser> AuthUsers { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
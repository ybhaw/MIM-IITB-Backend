using Microsoft.EntityFrameworkCore;
using MIM_IITB.Data.Models;

namespace MIM_IITB.Config
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
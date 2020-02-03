﻿using Microsoft.EntityFrameworkCore;
using MIM_IITB.Data.Entities;

namespace MIM_IITB.Helpers
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<Intake> Intakes { get; set; }
        public DbSet<IntakeBatch> IntakeBatches { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AuthUser> AuthUsers { get; set; }
        public DbSet<Cook> Cook { get; set; }
        public DbSet<Outtake> Outtake { get; set; }
        public DbSet<OuttakeBatch> OuttakeBatch { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Entities
{
    public class RestaurantDBContext : DbContext
    {
        private string _connection = "Server=(localdb)\\mssqllocaldb;Database=ReastaurantDb;Trusted_Connection=True;";
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().Property(r => r.Name).IsRequired().HasMaxLength(30);

            modelBuilder.Entity<Dish>().Property(d => d.Name).IsRequired();

            modelBuilder.Entity<Address>().Property(a => a.City).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Address>().Property(a => a.Street).IsRequired().HasMaxLength(50);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
        }
    }
}

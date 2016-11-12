using HubCafe.Models;
using Microsoft.EntityFrameworkCore;

namespace Hubcafe.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pasta> Pastas { get; set; }
        public DbSet<Salad> Salads { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().ToTable("Pizza");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Salad>().ToTable("Salad");
            modelBuilder.Entity<Pasta>().ToTable("Pasta");
        }
    }
}
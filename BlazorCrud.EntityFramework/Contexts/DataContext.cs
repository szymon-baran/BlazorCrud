using BlazorCrud.Shared.Dictionaries;
using BlazorCrud.Shared.Dictionaries.Enums;
using BlazorCrud.Shared.Domain;
using BlazorCrud.Shared.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Server.EntityFramework
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                new Brand() { Id = 1, Name = "LEGO" },
                new Brand() { Id = 2, Name = "Hot Wheels" },
                new Brand() { Id = 3, Name = "Funko" },
                new Brand() { Id = 4, Name = "Marvel" }
            );
            modelBuilder.Entity<Toy>().HasData(
                new Toy() { Id = 1, Name = "Star Wars Star Destroyer", ToyType = ToyType.Bricks, BrandId = 1 },
                new Toy() { Id = 2, Name = "Pop Cyberpunk 2077 - Johnny Silverhand", ToyType = ToyType.Figure, BrandId = 3 },
                new Toy() { Id = 3, Name = "Honda Civic Type S", ToyType = ToyType.Figure, BrandId = 2 },
                new Toy() { Id = 4, Name = "Spiderman - The Game (PS5)", ToyType = ToyType.Game, BrandId = 4 },
                new Toy() { Id = 5, Name = "Iron Man Action Figure", ToyType = ToyType.Figure, BrandId = 4 },
                new Toy() { Id = 6, Name = "Hulk Action Figure", ToyType = ToyType.Figure, BrandId = 4 }
            );
        }

        public DbSet<Toy> Toys { get; set; }
        public DbSet<Brand> Brands { get; set; }

    }
}

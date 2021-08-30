using Microsoft.EntityFrameworkCore;
using System;
using WeatherService.API.Models;

namespace WeatherService.API.Infrastructure
{
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Weather> Weathers { get; set; }

        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = new Guid("4848914d-89a5-4fa9-adec-a87bdb1242d0"),
                    Name = "Minsk"
                },
                new City
                {
                    Id = new Guid("915ccda2-9d44-425e-87fb-bd370b40925e"),
                    Name = "Gomel"
                },
                new City
                {
                    Id = new Guid("579a4438-c200-4f73-a250-3598099a8dc1"),
                    Name = "Vitebsk"
                },
                new City
                {
                    Id = new Guid("2f1f200f-2e4c-4a85-bb81-beb5aad73a95"),
                    Name = "Grodno"
                },
                new City
                {
                    Id = new Guid("8f5fb81d-cc18-4014-beae-756543e07596"),
                    Name = "Mogilev"
                },
                new City
                {
                    Id = new Guid("d1e4e028-55d2-42b0-bb3a-c49e50ee30e2"),
                    Name = "Brest"
                }
            );
        }
    }
}

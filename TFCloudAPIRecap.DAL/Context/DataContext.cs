using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCloudAPIRecap.DAL.Entities;
using TFCloudAPIRecap.DAL.EntitiesConfig;

namespace TFCloudAPIRecap.DAL.Context
{
    public class DataContext : DbContext
    {
        private string connectionString = @"Data Source=DESKTOP-56GOFPS\DEVPERSO;Initial Catalog=EFPokemonCloud;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public DbSet<Pokemon> Pokedex { get; set; }
        public DbSet<PokemonType> Typelist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PokemonConfig());
            modelBuilder.ApplyConfiguration(new Type_PokemonConfig());
        }
    }
}

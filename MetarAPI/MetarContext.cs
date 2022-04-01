using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using MetarAPI.Models.DataModels;

namespace MetarAPI
{
    public class MetarContext : DbContext
    {
        // <summary>
        // This is the Entity Framework DbContext class for the library. The user has 2 choices for using this context.
        // 1) Call and instanatiate the Context directly by instantiating with their connection string, and may then manipulate the data as they see fit
        // 2) Instantiate the MetarAPI object. This will instantiate a new MetarContext, but also provided built in functions to filter and manipulate data
        // </summary>
        public DbSet<Metar> Metars { get; set; }
        public DbSet<SkyCondition> SkyConditions { get; set; }
        public DbSet<QualityFlags> QualityFlags { get; set; }

        private string _conn { get; set; }

        public MetarContext(string conn)
        {
            _conn = conn;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_conn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Metar>()
                .HasIndex(raw => raw.RawText)
                .IsUnique();
        }
    }
}

#nullable disable
using System.Diagnostics;
using BlazorSandbox.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorSandbox.Data
{
    public partial class SpaceOperaDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }


        public DbSet<Race> Races { get; set; }


        public DbSet<Planet> Planets { get; set; }


        public DbSet<Sector> Sectors { get; set; }


        public DbSet<SolarSystem> Systems { get; set; }


        public DbSet<Territory> Territories { get; set; }


        public string DbPath { get; } = "c:\\src\\spaceopera.db";


        public string ConstructorCalled { get; set; }


        public SpaceOperaDbContext()
        {
            //var folder = Environment.SpecialFolder.LocalApplicationData;
            //var path = Environment.GetFolderPath(folder);
            //DbPath = System.IO.Path.Join(path, "spaceopera.db");

            ConstructorCalled = "default";
        }


        public SpaceOperaDbContext(DbContextOptions<SpaceOperaDbContext> options) : base(options)
        {
            ConstructorCalled = "service";
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Need this for doing Add-Migrations in the Package Manager Console
            if (ConstructorCalled == "default")
            {
                options.UseSqlite($"Data Source={DbPath}");
            }

            //options
            //    .LogTo(message => Debug.WriteLine(message))
            //    .EnableSensitiveDataLogging();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }


        public void SeedData(ModelBuilder modelBuilder)
        {
            // Races
            var human = new Race(1, "Human", "Human");
            var sith = new Race(2, "Sith", "Humanoid with black skin with bright red markings");
            var wookie = new Race(3, "Wookie", "Very tall, harry humanoid, resembling bigfoot");
            var sandpeople = new Race(4, "Sand People", "Humanoid wrapped in clothe and communicate making noises sounding like donkeys");
            var jawa = new Race(5, "Jawa", "Very small humanoid wearing brown robes");
            var ewok = new Race(6, "Ewok", "Small teddy bear looking humanoid");

            modelBuilder
                .Entity<Race>()
                .HasData(human, sith, wookie, sandpeople, jawa, ewok);

            // Territories
            var outerrim = new Territory(2, "Outer Rim");
            var coreworlds = new Territory(1, "Core Worlds");

            modelBuilder
                .Entity<Territory>()
                .HasData(outerrim, coreworlds);

            // Sectors
            var arkanis = new Sector(1, "Arkanis", outerrim.Id);
            var s_corellia = new Sector(2, "Corellia", coreworlds.Id);

            modelBuilder
                .Entity<Sector>()
                .HasData(arkanis, s_corellia);

            // Systems
            var tatoo = new SolarSystem(1, "Tatoo", arkanis.Id);

            modelBuilder
                .Entity<SolarSystem>()
                .HasData(tatoo);

            // Planets
            var tatooine_natives = new List<Race>() { human, sandpeople, jawa };
            var tatooine = new Planet(1, "Tatooine", tatoo.Id);//, tatooine_natives);

            var corellia_natives = new List<Race>() { human };
            var corellia = new Planet(2, "Corellia", tatoo.Id);//, corellia_natives);

            modelBuilder
                .Entity<Planet>()
                .HasData(tatooine, corellia);

            // Characters
            var luke = new Character(1, "Luke", "Skywalker", tatooine.Id, human.Id);
            var han = new Character(2, "Han", "Solo", corellia.Id, human.Id);

            modelBuilder
                .Entity<Character>()
                .HasData(luke, han);
        }
    }
}

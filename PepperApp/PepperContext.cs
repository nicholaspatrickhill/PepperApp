using Microsoft.EntityFrameworkCore;
using PepperApp.Entities;
using static PepperApp.Entities.DefaultPeppers;

namespace PepperApp.Data
{
    public class PepperContext : DbContext
    {
        public DbSet<Pepper> Peppers { get; set; }

        private readonly string _dbPath;

        public PepperContext()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var parentDirectory = Directory.GetParent(baseDirectory);

            while (parentDirectory != null && parentDirectory.Name != "PepperApp")
            {
                parentDirectory = Directory.GetParent(parentDirectory.FullName);
            }

            _dbPath = parentDirectory != null ? Path.Combine(parentDirectory.FullName, "pepper.db") : Path.Combine(baseDirectory, "pepper.db");

            Console.WriteLine("Database file path: " + _dbPath);

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={_dbPath}");

        // Seeds the database with default peppers from the dictionary in the Domain project
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var pepper in defaultPeppers)
            {
                modelBuilder.Entity<Pepper>().HasData(pepper.Value);
            }
        }
    }
}
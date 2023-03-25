using Microsoft.EntityFrameworkCore;
using PepperApp.Entities;
using static PepperApp.Entities.DefaultPeppers;

namespace PepperApp.Data
{
    public class PepperContext : DbContext
    {
        public PepperContext(DbContextOptions<PepperContext> options) : base(options)
        {
        }

        public DbSet<Pepper> Peppers { get; set; }

        private readonly string? _dbPath;

        public PepperContext()
        {
            if (OperatingSystem.IsWindows())
            {
                var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var dbDirectory = Path.Combine(appDataPath, "PepperApp");
                if (!Directory.Exists(dbDirectory))
                {
                    Directory.CreateDirectory(dbDirectory);
                }
                _dbPath = Path.Combine(dbDirectory, "pepper.db");
            }
            else if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
            {
                var homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                var dbDirectory = Path.Combine(homePath, ".local", "share", "PepperApp");
                if (!Directory.Exists(dbDirectory))
                {
                    Directory.CreateDirectory(dbDirectory);
                }
                _dbPath = Path.Combine(dbDirectory, "pepper.db");
            }
            else
            {
                // Unsupported operating system
                throw new PlatformNotSupportedException();
            }

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
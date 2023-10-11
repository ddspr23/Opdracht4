using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Opdracht4.core
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<Gast> Gasten { get; set; }
        public DbSet<Attractie> Attracties { get; set; }
        public DbSet<Reservering> Reserveringen { get; set; }
        public DbSet<Onderhoud> Onderhoud { get; set; }
        public DbSet<Medewerker> Medewerkers { get; set; }

        public DatabaseContext()
            : base()
        {
            //
        }

        public async Task<bool> Boek(Gast _g, Attractie _a, DateTimeBereik _dtb)
        {
            return await Task.Run(async () =>
            {
                if(await _a.Vrij(this, _dtb))
                {
                   Reserveringen.Add(new Reservering() { _attr = _a, _dtb = _dtb, _gast = _g });
                   return true;
                }

                return false;
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            MySqlConnectionStringBuilder _sql = new()
            {
                Server = "localhost",
                Port = 3306,
                Database = "cs",
                UserID = "root",
                Password = "Day##n@786"
            }; // Deze moeten je niet gebruiken. Dit is voor een remove connection jullie gebruiken localdb. Jullie line Hieronder zou er zo uit moeten zien:
               //      'optionsBuilder.useSql("Server=(localdb)\v11.0;Integrated Security=true;")'

            optionsBuilder.UseMySQL(_sql.ToString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medewerker>().ToTable("medewerker");
            modelBuilder.Entity<Attractie>().ToTable("attractie");
            modelBuilder.Entity<Gast>().ToTable("gast");
            modelBuilder.Entity<Reservering>().ToTable("reservering");
            modelBuilder.Entity<Onderhoud>().ToTable("onderhoud");
        }
    }
}

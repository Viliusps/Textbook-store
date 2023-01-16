using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace backend.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<Administratorius> administratorius { get; set; }
        public DbSet<Kurjeris> kurjeris { get; set; }
        public DbSet<Marsrutas> marsrutas { get; set; }
        public DbSet<marsruto_taskas> marsruto_taskas { get; set; }
        public DbSet<Pardavejas> pardavejas { get; set; }
        public DbSet<Pirkejas> pirkejas { get; set; }
        public DbSet<Populiarumas> populiarumas { get; set; }
        public DbSet<Pranesimas> pranesimas { get; set; }
        public DbSet<Rezervacija> rezervacija { get; set; }
        public DbSet<Siuntinys> siuntinys { get; set; }
        public DbSet<Statistika> statistika { get; set; }
        public DbSet<Uzsakymas> uzsakymas { get; set; }
        public DbSet<Vadovelis> vadovelis { get; set; }
        public DbSet<Vartotojas> vartotojas { get; set; }
        public DbSet<vartotojo_parduodami_vadoveliai> vartotojo_parduodami_vadoveliai { get; set; }
        
    }
}

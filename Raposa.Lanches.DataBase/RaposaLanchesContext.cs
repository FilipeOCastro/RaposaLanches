using Microsoft.EntityFrameworkCore;
using System;

namespace Raposa.Lanches.DataBase
{
    public class RaposaLanchesContext : DbContext
    {
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<LancheIngrediente> LancheIngredientes { get; set; }

        private readonly string _connectionString;
        public RaposaLanchesContext()
        {
            _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RaposaLanches;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            optionsBuilder.UseLazyLoadingProxies();
        }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LancheIngrediente>()
                .HasKey(x => new { x.LancheId, x.IngredienteId });

            modelBuilder.Entity<LancheIngrediente>()
            .HasOne<Lanche>(e => e.Lanche)
            .WithMany(p => p.LancheIngredientes);

            modelBuilder.Entity<LancheIngrediente>()
            .HasOne<Ingrediente>(e => e.Ingrediente)
            .WithMany(p => p.LancheIngredientes);
        }
    }
}

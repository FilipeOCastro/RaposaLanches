using Microsoft.EntityFrameworkCore;
using System;

namespace Raposa.Lanches.DataBase
{
    public class RaposaLanchesContext : DbContext
    {
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<LancheIngrediente> LancheIngredientes { get; set; }

        public RaposaLanchesContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {         
            modelBuilder.Entity<Lanche>()
                .HasData(new Lanche { ID = 1, Nome = "x-salada" },
                         new Lanche { ID = 2, Nome = "x-salada bacon" },
                         new Lanche { ID = 3, Nome = "x-egg" },
                         new Lanche { ID = 4, Nome = "duplo bacon" });


            modelBuilder.Entity<Ingrediente>()
                .HasData(new Ingrediente { ID = 1, Nome = "Hamburguer", Valor = 4.5m },
                         new Ingrediente { ID = 2, Nome = "Pão", Valor = 4.75m },
                         new Ingrediente { ID = 3, Nome = "Queijo", Valor = 4 },
                         new Ingrediente { ID = 4, Nome = "Tomate", Valor = 1 },
                         new Ingrediente { ID = 5, Nome = "Alface", Valor = 1 },
                         new Ingrediente { ID = 6, Nome = "Bacon", Valor = 4 },
                         new Ingrediente { ID = 7, Nome = "Ovo", Valor = 2 },
                         new Ingrediente { ID = 8, Nome = "Cebola Roxa", Valor = 1 },
                         new Ingrediente { ID = 9, Nome = "Pão australiano", Valor = 5 });


            modelBuilder.Entity<LancheIngrediente>()
                .HasData(new LancheIngrediente {ID = 1, LancheId = 1, IngredienteId = 1 },
                         new LancheIngrediente {ID = 2, LancheId = 1, IngredienteId = 2 },
                         new LancheIngrediente {ID = 3, LancheId = 1, IngredienteId = 4 },
                         new LancheIngrediente {ID = 4, LancheId = 1, IngredienteId = 5 },
                         new LancheIngrediente {ID = 5, LancheId = 2, IngredienteId = 1 },
                         new LancheIngrediente {ID = 6, LancheId = 2, IngredienteId = 2 },
                         new LancheIngrediente {ID = 7, LancheId = 2, IngredienteId = 4 },
                         new LancheIngrediente {ID = 8, LancheId = 2, IngredienteId = 5 },
                         new LancheIngrediente {ID = 9, LancheId = 2, IngredienteId = 6 },
                         new LancheIngrediente {ID = 10, LancheId = 3, IngredienteId = 1 },
                         new LancheIngrediente {ID = 11, LancheId = 3, IngredienteId = 2 },
                         new LancheIngrediente {ID = 12, LancheId = 3, IngredienteId = 7 },
                         new LancheIngrediente {ID = 13, LancheId = 4, IngredienteId = 1 },
                         new LancheIngrediente {ID = 14, LancheId = 4, IngredienteId = 1 },
                         new LancheIngrediente {ID = 15, LancheId = 4, IngredienteId = 2 },
                         new LancheIngrediente {ID = 16, LancheId = 4, IngredienteId = 3 },
                         new LancheIngrediente {ID = 17, LancheId = 4, IngredienteId = 6 }
                );
        }
    }
}

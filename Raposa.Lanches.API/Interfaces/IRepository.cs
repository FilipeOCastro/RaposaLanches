using Raposa.Lanches.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raposa.Lanches.API.Interfaces
{
    public interface IRepository
    {
        public List<Lanche> GetAllLanches();
        public Lanche InsertLanchee(Lanche lanche);
        public void DeleteLanche(int id);

        public void InsertIngredientes(int lancheID, int[] ingredientesIds);     
        
        public List<Ingrediente> GetAllIngredientes();
        public Ingrediente InsertIngrediente(Ingrediente ingrediente);
        public void UpdateIngrediente(Ingrediente ingrediente);
        public void DeleteIngrediente(int id);
    }
}

using Raposa.Lanches.API.Interfaces;
using Raposa.Lanches.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raposa.Lanches.API.Repository
{
    public class RaposaLanchesRepository : IRepository
    {
        private readonly RaposaLanchesContext _context;

        public RaposaLanchesRepository(RaposaLanchesContext context)
        {
            _context = context;
        }

        public List<Ingrediente> GetAllIngredientes()
        {
            return _context.Ingredientes.ToList();
        }

        public List<Lanche> GetAllLanches()
        {
            return _context.Lanches.ToList();
        }

        public Ingrediente InsertIngrediente(Ingrediente ingrediente)
        {
            _context.Add(ingrediente);
            _context.SaveChanges();

            return ingrediente;
        }

        public void DeleteIngrediente(int id)
        {
            var objDelete = _context.Ingredientes.Find(id);
            _context.Remove(objDelete);

            _context.SaveChanges();
        }

        public Lanche InsertLanchee(Lanche lanche)
        {
            _context.Add(lanche);
            _context.SaveChanges();

            return lanche;
        }

        public void DeleteLanche(int id)
        {
            var objDelete = _context.Lanches.Find(id);
            _context.Remove(objDelete);

            _context.SaveChanges();
        }

        public void InsertIngredientes(int lancheID, int[] ingredientesIds)
        {
            if (ingredientesIds != null)
            {
                foreach (var item in ingredientesIds)
                    _context.Add(new LancheIngrediente { LancheId = lancheID, IngredienteId = item });

                _context.SaveChanges();
            }            
        }

        public void UpdateIngrediente(Ingrediente ingredienteUpdate)
        {            
            _context.Update(ingredienteUpdate);
            _context.SaveChanges();
        }
    }
}

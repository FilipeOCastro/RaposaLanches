using System.Collections.Generic;
using System.Linq;

namespace Raposa.Lanches.DataBase.Repostitories.EFCore
{
    public class IngredientesRepository : IIngredientesRepository
    {
        private readonly RaposaLanchesContext _context;

        public IngredientesRepository(RaposaLanchesContext context)
        {
            _context = context;
        }


        public List<Ingrediente> GetAllIngredientes()
        {
            return _context.Ingredientes.ToList();
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

        public void UpdateIngrediente(Ingrediente ingredienteUpdate)
        {
            _context.Update(ingredienteUpdate);
            _context.SaveChanges();
        }
    }
}
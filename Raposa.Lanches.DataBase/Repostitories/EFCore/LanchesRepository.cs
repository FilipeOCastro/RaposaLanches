using System.Collections.Generic;
using System.Linq;

namespace Raposa.Lanches.DataBase.Repostitories.EFCore
{
    public class LanchesRepository : ILanchesRepository
    {
        private readonly RaposaLanchesContext _context;

        public LanchesRepository(RaposaLanchesContext context)
        {
            _context = context;
        }


        public List<Lanche> GetAllLanches()
        {
            return _context.Lanches.ToList();
        }

        public Lanche InsertLanche(Lanche lanche)
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
    }
}
using System.Collections.Generic;

namespace Raposa.Lanches.DataBase.Repostitories
{
    public interface ILanchesRepository
    {
        List<Lanche> GetAllLanches();

        Lanche InsertLanche(Lanche lanche);

        void DeleteLanche(int id);

        void InsertIngredientes(int lancheID, int[] ingredientesIds);
    }
}
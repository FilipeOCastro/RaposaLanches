using System.Collections.Generic;

namespace Raposa.Lanches.DataBase.Repostitories
{
    public interface IIngredientesRepository
    {
        List<Ingrediente> GetAllIngredientes();

        Ingrediente InsertIngrediente(Ingrediente ingrediente);

        void DeleteIngrediente(int id);

        void UpdateIngrediente(Ingrediente ingredienteUpdate);
    }
}
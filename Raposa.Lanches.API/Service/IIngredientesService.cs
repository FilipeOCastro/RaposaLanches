using Raposa.Lanches.API.Model;
using System.Collections.Generic;

namespace Raposa.Lanches.API.Service
{
    public interface IIngredientesService
    {
        List<IngredienteModel> GetAllIngredientes();

        IngredienteModel InsertIngrediente(IngredienteModel ingredienteModel);

        void DeleteIngrediente(int id);

        void UpdateIngrediente(IngredienteModel ingredienteModel);
    }
}
using Raposa.Lanches.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raposa.Lanches.API.Interfaces
{
    public interface IService
    {
        public List<LancheModel> GetAllLanches();
        public LancheModel InsertLanche(LancheModel lanche);
        public void DeleteLanche(int id);

        public List<IngredienteModel> GetAllIngredientes();
        public IngredienteModel InsertIngrediente(IngredienteModel ingrediente);
        public void UpdateIngrediente(IngredienteModel ingrediente);
        public void DeleteIngrediente(int id);
    }
}

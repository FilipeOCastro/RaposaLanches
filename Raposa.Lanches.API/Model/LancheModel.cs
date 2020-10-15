using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raposa.Lanches.API.Model
{
    public class LancheModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int[] IngredientesIds { get; set; }
        public List<LancheIngredienteModel> LancheIngredientes { get; set; }
    }
}

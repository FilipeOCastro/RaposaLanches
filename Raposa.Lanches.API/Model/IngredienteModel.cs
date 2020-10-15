using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raposa.Lanches.API.Model
{
    public class IngredienteModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public decimal Valor { get; set; }
    }
}

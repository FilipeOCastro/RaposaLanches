using System;
using System.Collections.Generic;
using System.Text;

namespace Raposa.Lanches.DataBase
{
    public class LancheIngrediente
    {
        public int LancheId { get; set; }
        public virtual Lanche Lanche { get; set; }
        public int IngredienteId { get; set; }
        public virtual Ingrediente Ingrediente { get; set; }

    }
}

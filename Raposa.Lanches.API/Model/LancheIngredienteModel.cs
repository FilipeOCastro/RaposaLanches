﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raposa.Lanches.API.Model
{
    public class LancheIngredienteModel
    {       
        public int IngredienteId { get; set; }
        public  IngredienteModel Ingrediente { get; set; }
    }
}

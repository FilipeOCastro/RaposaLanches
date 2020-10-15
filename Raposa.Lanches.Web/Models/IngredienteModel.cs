using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Raposa.Lanches.Web.Models
{
    public class IngredienteModel
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}

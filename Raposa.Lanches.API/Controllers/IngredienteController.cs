using Microsoft.AspNetCore.Mvc;
using Raposa.Lanches.API.Model;
using Raposa.Lanches.API.Service;
using System.Collections.Generic;

namespace Raposa.Lanches.API.Controllers
{
    [ApiController, Route("[controller]")]
    public class IngredienteController : ControllerBase
    {
        private IIngredientesService _ingredientesService;

        public IngredienteController(IIngredientesService ingredientesService)
        {
            _ingredientesService = ingredientesService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<IngredienteModel>> Get()
            => Ok(_ingredientesService.GetAllIngredientes());

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ingredientesService.DeleteIngrediente(id);
        }

        [HttpPost]
        public ActionResult<IngredienteModel> Post(IngredienteModel ingrediente)
            => Ok(_ingredientesService.InsertIngrediente(ingrediente));

        [HttpPut]
        public void Update(IngredienteModel ingrediente)
        {
            _ingredientesService.UpdateIngrediente(ingrediente);

        }
    }
}
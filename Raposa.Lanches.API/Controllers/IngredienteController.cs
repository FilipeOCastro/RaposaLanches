using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raposa.Lanches.API.Interfaces;
using Raposa.Lanches.API.Model;

namespace Raposa.Lanches.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("[controller]")]
    public class IngredienteController : ControllerBase
    {
        
        private IService _service;

        public IngredienteController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<IngredienteModel> Get()
        {
            var result = _service.GetAllIngredientes();

            return result;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteIngrediente(id);
        }


        [HttpPost]
        public IngredienteModel Post(IngredienteModel ingrediente)
        {
            var result = _service.InsertIngrediente(ingrediente);

            return result;
        }

    }

}
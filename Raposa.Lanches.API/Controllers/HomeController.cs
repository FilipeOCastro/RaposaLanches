using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Raposa.Lanches.API.Interfaces;
using Raposa.Lanches.API.Model;
using Raposa.Lanches.DataBase;

namespace Raposa.Lanches.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private IService _service;

        public HomeController(IService service)
        {
            _service = service;
        }  
        
        [HttpGet]
        public IEnumerable<LancheModel> Get()
        {
            var result = _service.GetAllLanches();

            return result;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteLanche(id);
        }


        [HttpPost]
        public LancheModel Post(LancheModel lanche)
        {
            var result = _service.InsertLanche(lanche);

            return result;
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Raposa.Lanches.API.Model;
using Raposa.Lanches.API.Service;
using System.Collections.Generic;

namespace Raposa.Lanches.API.Controllers
{
    [ApiController, Route("[controller]")]
    public class LancheController : ControllerBase
    {
        private ILanchesService _lanchesService;

        public LancheController(ILanchesService lanchesService)
        {
            _lanchesService = lanchesService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<LancheModel>> Get()
            => Ok(_lanchesService.GetAllLanches());

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _lanchesService.DeleteLanche(id);
        }

        [HttpPost]
        public ActionResult<LancheModel> Post(LancheModel lanche)
            => Ok(_lanchesService.InsertLanche(lanche));
    }
}

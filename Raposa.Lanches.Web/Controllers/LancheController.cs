using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Raposa.Lanches.Web.Models;
using RestSharp;

namespace Raposa.Lanches.Web.Controllers
{
    public class LancheController : Controller
    {        
        private readonly IRestClient _restClient;
        private readonly IRestRequest _restRequest;
        private IConfiguration _configuration;

        public LancheController(IRestClient restClient, IRestRequest restRequest, IConfiguration Configuration)
        {
            _restClient = restClient;
            _restRequest = restRequest;
            _configuration = Configuration;

            _restClient.BaseUrl = new Uri(_configuration["API:BaseURL"]);
        }

        public IActionResult Index()
        {
            _restRequest.Resource = "Home";
            _restRequest.Method = Method.GET;

            var response = _restClient.Execute<List<LancheModel>>(_restRequest);

            return View(response.Data);
        }

        public IActionResult Create()
        {
            _restRequest.Resource = "Ingrediente";
            _restRequest.Method = Method.GET;

            var response = _restClient.Execute<List<IngredienteModel>>(_restRequest);

            ViewBag.Ingredientes = response.Data;
            return View();

        }

        [HttpPost]
        public IngredienteModel AdicionarIngrediente(int id)
        {
            _restRequest.Resource = "Ingrediente";
            _restRequest.Method = Method.GET;

            var response = _restClient.Execute<List<IngredienteModel>>(_restRequest);

            return response.Data.Where(p => p.ID == id).Single();
        }
        
      
        public ActionResult Delete(int ID)
        {
            try
            {
                _restRequest.Resource = $"Home/{ID}";
                _restRequest.Method = Method.DELETE;

                _restClient.Execute(_restRequest);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(LancheModel lanche)
        {
            try
            {
                _restRequest.Resource = "Home";
                _restRequest.Method = Method.POST;

                _restRequest.AddJsonBody(lanche);

                _restClient.Execute(_restRequest);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
    }
}
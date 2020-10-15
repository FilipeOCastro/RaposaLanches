using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Raposa.Lanches.Web.Models;
using RestSharp;

namespace Raposa.Lanches.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRestClient _restClient;
        private readonly IRestRequest _restRequest;
        private IConfiguration _configuration;

        public HomeController(IRestClient restClient, IRestRequest restRequest, ILogger<HomeController> logger, IConfiguration Configuration) 
        {
            _restClient = restClient;
            _restRequest = restRequest;
            _logger = logger;
            _configuration = Configuration;

            _restClient.BaseUrl = new Uri(_configuration["API:BaseURL"]);
        }


        public IActionResult Index()
        {           
            _restRequest.Resource = "Home";
            _restRequest.Method = Method.GET;

            var response = _restClient.Execute<List<LancheModel>>(_restRequest);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)            
                ViewBag.Lanches = response.Data;
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }       
    }
}

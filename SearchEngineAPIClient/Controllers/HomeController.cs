using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using ProductsAPIClient.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace ProductsAPIClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }
        private string URLBase
        {
            get
            {
                return _config.GetSection("BaseURL").GetSection("URL").Value;
            }
        }

        public async Task<IActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                // return View();
                using (var response = await httpClient.GetAsync(URLBase + "weatherforecast"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<List<User>>(apiResponse); }
                return View();
            } 
        
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

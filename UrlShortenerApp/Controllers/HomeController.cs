using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlShortenerApp.Models;
using Microsoft.Extensions.Options;
using UrlShortenerApp.Helpers;

namespace UrlShortenerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<AppSettings> _config;

        public HomeController(IOptions<AppSettings> config)
        {
            this._config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string longUrl)
        {
            var apiUrl = _config.Value.ApiUrl + "/" + longUrl;
            var result = ApiGateway.PostRequestToUrl(apiUrl, "", "");
            return View();
        }
    }
}

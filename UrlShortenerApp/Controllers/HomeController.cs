using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using UrlShortenerApp.Helpers;
using UrlShortenerApp.Models;

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

        [HttpGet("{shorturl}")]
        public IActionResult Get(string shortUrl)
        {
            try
            {
                var apiUrl = _config.Value.ApiUrl + "api/shorturls/v1/shorturl?url=" + shortUrl;
                var result = ApiGateway.SendGetRequestToUrl(apiUrl, "", "");

                var urlData = JsonConvert.DeserializeObject<UrlData>(result);
                if(urlData.Status == "ok")
                    return Redirect(urlData.LongUrl);

            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return Redirect(shortUrl);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string longUrl)
        {
            try
            {
                var apiUrl = _config.Value.ApiUrl + "api/shorturls/v1/urlshortener";
                var jsonData = JObject.Parse("{'longurl': '" + longUrl + "'}");
                var result = ApiGateway.SendPostRequestToUrl(apiUrl, jsonData, "", "");

                var shortUrl = JsonConvert.DeserializeObject<UrlData>(result);
                return RedirectToAction(actionName: "Result", routeValues: shortUrl);

            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }

        public IActionResult Result(UrlData urlData)
        {
            if (urlData == null )
            {
                return NotFound();
            }

            return View(urlData);
        }
    }
}

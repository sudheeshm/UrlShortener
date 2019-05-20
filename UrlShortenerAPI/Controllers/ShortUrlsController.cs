using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using UrlShortenerAPI.Models;
using UrlShortenerAPI.Services;

namespace UrlShortenerAPI.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ShortUrlsController : ControllerBase
    {
        private readonly IUrlService _service;

        public ShortUrlsController(IUrlService service)
        {
            _service = service;
        }

        [HttpGet("v1/shorturl")]
        public ActionResult<UrlData> GetByShortUrl(string url)
        {
            return _service.GetByShortUrl(url);
        }

        [HttpPost]
        [Route("v1/[action]")]
        public ActionResult<UrlData> UrlShortener([FromBody] JObject param)
        {
            var url = (param != null && param["longurl"] != null) ? param["longurl"].ToString() : "";
            return _service.CreateShortUrl(url);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Models;
using UrlShortener.Services;
using Newtonsoft.Json.Linq;

namespace UrlShortener.Controllers
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

            //var rediretUrl =  urlData != null ? urlData.LongUrl : shorturl;
            //return Redirect(rediretUrl);
        }

        [HttpPost("v1/longurl")]
        public ActionResult<UrlData> GetByLongUrl([FromBody] JObject param)
        {
            var url = (param != null && param["longurl"] != null) ? param["longurl"].ToString() : "";
            return _service.GetByLongUrl(url);
        }

        [HttpPost]
        [Route("v1/[action]")]
        public ActionResult<UrlData> UrlShortener(string url)
        {
            return _service.CreateShortUrl(url);
        }
    }
}
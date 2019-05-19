using Microsoft.AspNetCore.Mvc;
using UrlShortener.Models;
using UrlShortener.Services;
using System.Collections.Generic;

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

        [HttpGet("v1/{shorturl}")]
        public ActionResult<UrlData> Get(string shorturl)
        {
            return _service.GetByShortUrl(shorturl);

            //var rediretUrl =  urlData != null ? urlData.LongUrl : shorturl;
            //return Redirect(rediretUrl);
        }

        [HttpGet("v1/{longurl}")]
        public ActionResult<UrlData> GetByLongUrl(string longurl)
        {
            return _service.GetByLongUrl(longurl);
        }

        [HttpPost]
        [Route("v1/[action]")]
        public ActionResult<UrlData> UrlShortener(string url)
        {
            return _service.CreateShortUrl(url);
        }
    }
}
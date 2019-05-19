using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortenerAPI.Models;

namespace UrlShortenerAPI.Services
{
    public interface IUrlService
    {
        UrlData GetByLongUrl(string longUrl);
        UrlData GetByShortUrl(string shortUrl);
        UrlData CreateShortUrl(string longurl);
    }
}

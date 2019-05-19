using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.Services
{
    public interface IUrlService
    {
        UrlData GetByLongUrl(string longUrl);
        UrlData GetByShortUrl(string shortUrl);
        UrlData CreateShortUrl(string longurl);
    }
}

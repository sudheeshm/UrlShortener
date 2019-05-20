using System;
using Microsoft.Extensions.Options;
using UrlShortenerAPI.Models;
using UrlShortenerAPI.Helpers;
using UrlShortenerAPI.DataAccess;


namespace UrlShortenerAPI.Services
{
    public class UrlService : IUrlService
    {
        private readonly ILogger _logger = new LoggerImpl();
        private readonly AppSettings _config;

        public UrlService(IOptions<AppSettings> config)
        {
            _config = config.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="longUrl"></param>
        /// <returns></returns>
        public UrlData GetByLongUrl(string longUrl)
        {
            _logger.LogDebug("GetByLongUrl() called");

            var urlData = DataDB.ShortUrls.Find(x => x.LongUrl == longUrl);
            if (urlData != null)
                return urlData;

            //no data found, return an error
            return getErrorUrlData("", "no data found for this url");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shortUrl"></param>
        /// <returns></returns>
        public UrlData GetByShortUrl(string shortUrl)
        {
            _logger.LogDebug("GetByShortUrl() called");

            if (!String.IsNullOrEmpty(shortUrl))
            {
                if (!shortUrl.Contains(_config.UrlBase))
                    shortUrl = _config.UrlBase + shortUrl;

                var urlData = DataDB.ShortUrls.Find(x => x.ShortUrl == shortUrl);
                if (urlData != null)
                    return urlData;
            }

            //no data found, return an error
            return getErrorUrlData("", "no data found for this short url");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="longUrl"></param>
        /// <returns></returns>
        public UrlData CreateShortUrl(string longUrl)
        {
            _logger.LogDebug("CreateShortUrl() called");

            if (Uri.IsWellFormedUriString(longUrl, UriKind.Absolute))
            {
                //if we already computed for this url, get it from the db
                var urlExist = GetByLongUrl(longUrl);
                if( urlExist != null && urlExist.Status == "ok")
                    return urlExist;

                //create a new entry as we don't have this in the db
                var db = DataDB.ShortUrls;
                var id = db.Count > 0 ? db[db.Count - 1].Id + 1 : DataDB.StartId;
                var shortUrl = _config.UrlBase + ShortUrlHelper.Encode(id);

                var urlData = new UrlData
                {
                    LongUrl = longUrl,
                    Id = id,
                    ShortUrl = shortUrl,
                };
                db.Add(urlData);

                return urlData;
            }

            //we have an invalid url string. Return an error UrlData
            return getErrorUrlData(longUrl, "invalid url string format");
        }

        /// <summary>
        /// A UrlData with error details
        /// </summary>
        /// <param name="longUrl"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private UrlData getErrorUrlData(string longUrl, string message)
        {
            return new UrlData
            {
                LongUrl = longUrl,
                Status = "error",
                Message = message
            };
        }
    }
}

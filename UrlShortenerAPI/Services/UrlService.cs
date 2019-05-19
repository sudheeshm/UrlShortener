﻿using System.Collections.Generic;
using System;
using UrlShortener.Models;
using UrlShortener.Helpers;
using UrlShortener.DataAccess;

namespace UrlShortener.Services
{
    public class UrlService : IUrlService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="longUrl"></param>
        /// <returns></returns>
        public UrlData GetByLongUrl(string longUrl)
        {
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
            var urlData = DataDB.ShortUrls.Find(x => x.ShortUrl == shortUrl);
            if (urlData != null)
                return urlData;

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
            if (Uri.IsWellFormedUriString(longUrl, UriKind.Absolute))
            {
                //if we already computed for this url, get it from the db
                var urlExist = GetByLongUrl(longUrl);
                if( urlExist != null && urlExist.Status == "ok")
                    return urlExist;

                //create a new entry as we don't have this in the db
                var db = DataDB.ShortUrls;
                var id = db.Count > 0 ? db[db.Count - 1].Id + 1 : DataDB.StartId;
                var shortUrl = ShortUrlHelper.Encode(id);
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
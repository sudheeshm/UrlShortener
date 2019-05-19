using System.Collections.Generic;
using UrlShortener.Models;

namespace UrlShortener.DataAccess
{
    public static class DataDB
    {
        /// <summary>
        /// _shortUrls : A list to store shortUrl collection. 
        /// This must be stored in a DB for the prod env. But for this demo solution, this is fine.
        /// </summary>
        private static List<UrlData> _shortUrls = new List<UrlData>();

        public static int StartId = 1000001;

        public static List<UrlData> ShortUrls = new List<UrlData>();

    }
}

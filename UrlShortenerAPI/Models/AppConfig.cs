using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Models
{
    public class AppSettings
    {
        public string ApplicationName { get; set; }
        public string Version { get; set; }
        public string UrlBase { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortenerAPI.Models
{
    public class AppSettings : IAppSettings
    {
        public string ApplicationName { get; set; }
        public string Version { get; set; }
        public string UrlBase { get; set; }

    }
}

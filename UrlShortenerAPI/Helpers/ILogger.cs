using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortenerAPI.Helpers
{
    public interface ILogger
    {
        void LogDebug(string text);
        void LogInfo(string text);
        void LogWarn(string text);
        void LogError(string text);
    }
}

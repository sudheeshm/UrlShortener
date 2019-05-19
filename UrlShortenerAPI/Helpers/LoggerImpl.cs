using NLog;

namespace UrlShortenerAPI.Helpers
{
    public class LoggerImpl :ILogger
    {
        private static Logger logger = LogManager.GetLogger("Logger");
        public void LogDebug(string text)
        {
            logger.Debug(text);
        }
        public void LogInfo(string text)
        {
            logger.Info(text);
        }
        public void LogWarn(string text)
        {
            logger.Warn(text);

        }
        public void LogError(string text)
        {
            logger.Error(text);
        }
    }
}

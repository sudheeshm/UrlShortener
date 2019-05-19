
namespace UrlShortenerAPI.Models
{
    public interface IAppSettings
    {
        string ApplicationName { get; set; }
        string Version { get; set; }
        string UrlBase { get; set; }
    }
}

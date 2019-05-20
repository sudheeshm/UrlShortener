
namespace UrlShortenerApp.Models
{
    public class UrlData
    {
        public int Id { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public string Status { get; set; } 
        public string Message { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace UrlShortenerAPI.Models
{
    public class UrlData
    {
        public int Id { get; set; }
        [Required]
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }

        public string Status { get; set; } = "ok";
        public string Message { get; set; } = "";
    }
}

using Microsoft.Extensions.Options;
using UrlShortenerAPI.Models;
using UrlShortenerAPI.Services;
using Xunit;

namespace UrlShortenerApiTest
{
    public class UnitTest1
    {
        [Fact]
        public void GetByLongUrlWithInvalidUrl()
        {
            //arrange
            var urlService = geturlService();

            //act
            var actual = urlService.GetByLongUrl("www.google.com");

            //assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void GetByShortUrlWithInvalidUrl()
        {
            //arrange
            var urlService = geturlService();

            //act
            var actual = urlService.GetByShortUrl("www.google.com");

            //assert
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData("https://www.google.com", "ok")]
        [InlineData("https://www.nuget.org/", "ok")]
        public void CreateShortUrlsWithValidData(string longUrl, string expectedStatus)
        {
            //arrange
            var urlService = geturlService();

            //act
            var actual = urlService.CreateShortUrl(longUrl).Status;

            //assert
            Assert.Equal(actual, expectedStatus);
        }


        private UrlService geturlService()
        {
            IOptions<AppSettings> someOptions = Options.Create<AppSettings>(new AppSettings());
            return new UrlService(someOptions);
        }
    }
}

using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;

namespace UrlShortenerApp.Helpers
{
    public static class ApiGateway
    {

        public static string SendPostRequestToUrl(string url, JObject jsonData, string user, string password)
        {
            var response = "";
            try
            {
                var taskitem = Task.Run(() => postRequestToUrl(url, jsonData, user, password));
                taskitem.Wait();

                response = taskitem.Result;
            }
            catch(Exception ex)
            {

            }
            return response;
        }

        public static string SendGetRequestToUrl(string url, string user, string password)
        {
            var response = "";
            try
            {
                var taskitem = Task.Run(() => getRequestToUrl(url, user, password));
                taskitem.Wait();

                response = taskitem.Result;
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        private static async Task<string> postRequestToUrl(string url, JObject jsonData, string user, string password)
        {
            var result = @"'status' : 'error'";

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);

                    //TODO: add authentication here

                    var content = new StringContent(jsonData.ToString(), Encoding.UTF8, "application/json");
                    var response = client.PostAsync(url, content);
                    result = await response.Result.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        private static async Task<string> getRequestToUrl(string url, string user, string password)
        {
            var result = @"'status' : 'error'";

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);

                    //TODO: add authentication here
                    var response = client.GetAsync(url);
                    result = await response.Result.Content.ReadAsStringAsync();
                }
            }
            catch(Exception ex)
            {

            }

            return result;
        }
    }
}

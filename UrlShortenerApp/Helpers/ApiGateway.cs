using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;

namespace UrlShortenerApp.Helpers
{
    public static class ApiGateway
    {

        public static string SendPostRequestToUrl(string url, string user, string password)
        {
            var response = "";
            try
            {
                var taskitem = Task.Run(() => postRequestToUrl(url, user, password));
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

        private static async Task<string> postRequestToUrl(string url, string user, string password)
        {
            var result = @"'status' : 'error'";
            string jsonInString = "";

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);

                    //TODO: add authentication here
                    var response = client.PostAsync(url, new StringContent(jsonInString, Encoding.UTF8, "application/json"));
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

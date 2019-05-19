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

        public static string PostRequestToUrl(string url, string user, string password)
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

        private static async Task<string> postRequestToUrl(string url, string user, string password)
        {
            var result = @"'status' : 'error'";
            string jsonInString = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                //TODO: add authentication here
                var response = client.PostAsync(url, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

               // if(response.IsCompletedSuccessfully)
               // {
                    result = await response.Result.Content.ReadAsStringAsync();
               // }

            }

            return result;
        }
    }
}

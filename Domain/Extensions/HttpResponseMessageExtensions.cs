using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;

namespace Domain.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static T GetContent<T>(this HttpResponseMessage response)
        {
            var message = response.Content.ReadAsStringAsync().Result;
            var content = JsonConvert.DeserializeObject<T>(message);
            return content;
        }

        public static string GetContentAsString(this HttpResponseMessage response)
        {
            return response.Content.ReadAsStringAsync().Result;
        }

        public static void EnsureSuccesOrPrintReason(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    var content = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                    var messsage = JsonConvert.SerializeObject(content, Formatting.Indented);
                    Console.WriteLine(response.ReasonPhrase);
                    Console.WriteLine(messsage);
                }
                catch (JsonReaderException)
                {
                    Debug.WriteLine(response.ReasonPhrase);
                    Debug.WriteLine(response.Content.ReadAsStringAsync().Result);
                }
                finally
                {
                    throw new HttpRequestException($"Statuscode does not indicate succes! {response.StatusCode}");
                }
            }
        }
    }
}

using Domain.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Domain.Helpers
{
    public static class ContentCreator
    {
        public static StringContent CreateJsonContent <T> (T content)
        {
            return new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, new MediaTypeHeaderValue("application/json").MediaType);
        }
    }
}

using Domain.Extensions;
using Domain.Helpers;
using Domain.Interfaces;
using Domain.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Controllers
{
    public class TokenController : IAuthorization
    {
        private readonly HttpClient _client;

        public TokenController()
        {
            _client = new HttpClient();
        }

        public Token GetToken(User user)
        {
            return GetTokenAsync(user).Result;
        }

        private async Task<Token> GetTokenAsync(User user)
        {
            var content = ContentCreator.CreateJsonContent(user);
            var response = await _client.PostAsync(Constants.BaseAddress + Constants.TokenUri, content);
            response.EnsureSuccesOrPrintReason();
            var token = response.GetContent<Token>();
            return token;
        }
    }
}

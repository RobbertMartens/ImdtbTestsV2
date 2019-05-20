using Domain.Extensions;
using Domain.Helpers;
using Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Controllers
{
    public class UserController
    {
        private HttpClient _client;

        public UserController() { _client = new HttpClient(); }


        public List<User> GetUsers()
        {
            return GetUsersAsync().Result;
        }

        public int GetUserId(string userName)
        {
            return GetUserIdAsync(userName).Result;
        }

        public string CreateUser(User newUser)
        {
            return PostUserAsync(newUser).Result;
        }



        private async Task<List<User>> GetUsersAsync()
        {
            var response = await _client.GetAsync(Constants.BaseAddress + Constants.UsersUri);
            var userList = response.GetContent<List<User>>();
            return userList;
        }

        private async Task<int> GetUserIdAsync(string userName)
        {
            var response = await _client.GetAsync(Constants.BaseAddress + Constants.UsersUri + userName);
            var userId = int.Parse(response.GetContentAsString());
            return userId;
        }
        
        private async Task<string> PostUserAsync(User newUser)
        {
            var content = ContentCreator.CreateJsonContent(newUser);
            var response = await _client.PostAsync(Constants.BaseAddress + Constants.UsersUri, content);
            var message = response.GetContentAsString();
            return message;
        }
    }
}

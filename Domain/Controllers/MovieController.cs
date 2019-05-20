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
    public class MovieController
    {
        private HttpClient _client;

        public MovieController() { _client = new HttpClient(); }



        public List<Movie> GetMovies()
        {
            return GetMoviesAsync().Result;
        }

        public string PostMovie(Movie movie)
        {
            return PostMovieAsync(movie).Result;
        }



        private async Task<List<Movie>> GetMoviesAsync()
        {
            var response = await _client.GetAsync(Constants.BaseAddress + Constants.MoviesUri);
            var movieList = response.GetContent<List<Movie>>();
            return movieList;
        }

        private async Task<string> PostMovieAsync(Movie movie)
        {
            var content = ContentCreator.CreateJsonContent(movie);
            var response = await _client.PostAsync(Constants.BaseAddress + Constants.MoviesUri, content);
            var succesText = response.GetContentAsString();
            return succesText;
        }
    }
}


using WebApp.Models;

namespace WebApp.Service
{
    public class MovieApi
    {
        private readonly HttpClient _httpClient;

        public MovieApi(IHttpClientFactory httpClient)
        {
           _httpClient = httpClient.CreateClient("MovieApi");
            _httpClient.BaseAddress = new Uri("https://localhost:7007/api/");
        }

        public async Task<List<Movie>> GetMoviesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Movie>>("movie");

            return response ?? new List<Movie>();
        }

       

        public async Task<Movie?> GetMovieAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Movie>($"movie/{id}");

        }

        public async Task<Movie?> AddMovieAsync(Movie movie)
        {
            var response = await _httpClient.PostAsJsonAsync("movie", movie);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Movie>();
            }
            return null;
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            var response = await _httpClient.PutAsJsonAsync($"movie/{movie.Id}", movie);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"movie/{id}");

            return response.IsSuccessStatusCode;
        }


    }
}

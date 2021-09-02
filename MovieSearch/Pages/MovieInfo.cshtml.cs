using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MovieSearch.Models;

namespace MovieSearch.Pages
{
    public class MovieInfoModel : PageModel
    {
        private readonly ILogger<MovieInfoModel> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public MovieModel Movie { get; set; } = null;
        public string ErrorString { get; set; }

        [BindProperty]
        public string Title { get; set; }

        public MovieInfoModel(ILogger<MovieInfoModel> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        private async Task<MovieModel> MakeRequest(IHttpClientFactory factory, string title)
        {
            var query = $"http://www.omdbapi.com/?apikey=78e51e6c&t={title}";
            var request = new HttpRequestMessage(HttpMethod.Get, query);
            var client = factory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                MovieModel movie = await response.Content.ReadFromJsonAsync<MovieModel>();
                ErrorString = null;
                return movie;
            }
            else
            {
                ErrorString = response.ReasonPhrase;
                return null;
            }
        }

        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            Movie = await MakeRequest(_clientFactory, Title);
        }
    }
}

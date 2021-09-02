using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using MovieSearch.Models;
using System.Net.Http.Json;

namespace MovieSearch.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
        }


        public void OnGet()
        {
            
        }

    }
}

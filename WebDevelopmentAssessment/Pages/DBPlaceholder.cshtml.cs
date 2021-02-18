using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDevelopmentAssessment.Pages
{
    public class PlaceholderModel : PageModel
    {
        private readonly ILogger<PlaceholderModel> _logger;

        public PlaceholderModel(ILogger<PlaceholderModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}

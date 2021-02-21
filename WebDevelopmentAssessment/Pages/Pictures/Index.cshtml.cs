using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebDevelopmentAssessment.Data;
using WebDevelopmentAssessment.Models;

namespace WebDevelopmentAssessment.Pages.Pictures
{
    public class IndexModel : PageModel
    {
        private readonly WebDevelopmentAssessment.Data.WebContentContext _context;

        public IndexModel(WebDevelopmentAssessment.Data.WebContentContext context)
        {
            _context = context;
        }

        public IList<Picture> Picture { get;set; }

        public async Task OnGetAsync()
        {
            Picture = await _context.Pictures.ToListAsync();
        }
    }
}

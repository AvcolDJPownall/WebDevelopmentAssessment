using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebDevelopmentAssessment.Data;
using WebDevelopmentAssessment.Models;

namespace WebDevelopmentAssessment.Pages.Tags
{
    public class IndexModel : PageModel
    {
        private readonly WebDevelopmentAssessment.Data.WebContentContext _context;

        public IndexModel(WebDevelopmentAssessment.Data.WebContentContext context)
        {
            _context = context;
        }

        public IList<Tag> Tag { get;set; }

        public async Task OnGetAsync()
        {
            Tag = await _context.Tags.ToListAsync();
        }
    }
}

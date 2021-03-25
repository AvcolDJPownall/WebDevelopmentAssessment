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
    public class DetailsModel : PageModel
    {
        private readonly WebDevelopmentAssessment.Data.WebContentContext _context;

        public DetailsModel(WebDevelopmentAssessment.Data.WebContentContext context)
        {
            _context = context;
        }

        public Tag Tag { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tag = await _context.Tags.FirstOrDefaultAsync(m => m.ID == id);

            if (Tag == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

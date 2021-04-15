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
    public class DetailsModel : PageModel
    {
        private readonly WebDevelopmentAssessment.Data.WebContentContext _context;

        public DetailsModel(WebDevelopmentAssessment.Data.WebContentContext context)
        {
            _context = context;
        }

        public Picture Picture { get; set; }
        public Tag AssignedTag { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Picture = await _context.Pictures.FirstOrDefaultAsync(m => m.PictureID == id);

            if (Picture == null)
            {
                return NotFound();
            }

            AssignedTag = await _context.Tags.FirstOrDefaultAsync(tag => tag.TagID == Picture.TagID);

            return Page();
        }
    }
}

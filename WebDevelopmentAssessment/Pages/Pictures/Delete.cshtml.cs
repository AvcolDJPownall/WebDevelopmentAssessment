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
    public class DeleteModel : PageModel
    {
        private readonly WebDevelopmentAssessment.Data.WebContentContext _context;

        public DeleteModel(WebDevelopmentAssessment.Data.WebContentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Picture Picture { get; set; }

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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Picture = await _context.Pictures.FindAsync(id);

            if (Picture != null)
            {
                _context.Pictures.Remove(Picture);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

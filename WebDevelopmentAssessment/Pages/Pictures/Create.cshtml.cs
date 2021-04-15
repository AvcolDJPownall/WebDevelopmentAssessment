using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDevelopmentAssessment.Data;
using WebDevelopmentAssessment.Models;

namespace WebDevelopmentAssessment.Pages.Pictures
{
    public class CreateModel : PageModel
    {
        private readonly WebDevelopmentAssessment.Data.WebContentContext _context;

        public CreateModel(WebDevelopmentAssessment.Data.WebContentContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            //return Page();
            AllTags = await _context.Tags.ToListAsync();
        }

        [BindProperty]
        public Picture Picture { get; set; }
        public IList<Tag> AllTags { get; set; }
        [BindProperty]
        public int SelectedTagID { get; set; }
        public MultiSelectList TagSelectionList { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Picture.TagID = SelectedTagID;
            _context.Pictures.Add(Picture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
